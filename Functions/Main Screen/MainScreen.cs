using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleATMApplication
{
    public partial class MainScreen : Form
    {
        // Inner class representing a transfer transaction
        public class TransferTransaction
        {
            public DateTime TransactionDate { get; set; }
            public string Recipient { get; set; }
            public decimal Amount { get; set; }
            public string Description { get; set; }

            public override string ToString()
            {
                return $"{TransactionDate}: {Recipient} - {Amount:C} - {Description}";
            }
        }

        private decimal accountBalance;
        private readonly List<TransferTransaction> transactions = new List<TransferTransaction>();
        private readonly int userId;
        private readonly DatabaseConnection dbConnection = new DatabaseConnection();

        private const int MaxRecentTransactions = 5;

        public MainScreen(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            ConfigureScreen();
            InitializeTransactionListView();
            LoadRecentTransactions();
            LoadAccountBalance();
        }

        private void ConfigureScreen()
        {
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            this.Size = new Size(screenBounds.Width, screenBounds.Height);
            this.Location = new Point(0, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }

        private void InitializeTransactionListView()
        {
            transactionsViewList.Columns.Clear();
            transactionsViewList.Columns.Add("Recipient", 100);
            transactionsViewList.Columns.Add("Description", 125);
            transactionsViewList.Columns.Add("Amount", 100);
            transactionsViewList.Columns.Add("Datetime", 150);
            transactionsViewList.View = View.Details;
        }

        private void LoadRecentTransactions()
        {
            transactionsViewList.Items.Clear();

            try
            {
                string connectionString = dbConnection.GetConnectionString();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT transferid, recipient_name, amount, transfer_datetime, description FROM transfers " +
                                   "WHERE accountid = @userId ORDER BY transfer_datetime DESC LIMIT @limit";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@limit", MaxRecentTransactions);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var transaction = new TransferTransaction
                                {
                                    TransactionDate = reader.GetDateTime("transfer_datetime"),
                                    Recipient = reader.GetString("recipient_name"),
                                    Amount = reader.GetDecimal("amount"),
                                    Description = reader.GetString("description")
                                };
                                AddTransactionToListView(transaction);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                ShowError("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("An unexpected error occurred: " + ex.Message);
            }
        }

        private void LoadAccountBalance()
        {
            try
            {
                string connectionString = dbConnection.GetConnectionString();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT balance FROM accounts WHERE id = @userId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        var balance = command.ExecuteScalar();

                        if (balance != null)
                        {
                            accountBalance = Convert.ToDecimal(balance);
                            balanceShowText.Text = accountBalance.ToString("C");
                        }
                        else
                        {
                            ShowError("Account not found.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                ShowError("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("An unexpected error occurred: " + ex.Message);
            }
        }

        private void AddTransactionToListView(TransferTransaction transaction)
        {
            if (transactions.Count >= MaxRecentTransactions)
            {
                transactions.RemoveAt(0);
            }
            transactions.Add(transaction);

            var listViewItem = new ListViewItem(transaction.Recipient)
            {
                SubItems =
                {
                    transaction.Description,
                    transaction.Amount.ToString("C"),
                    transaction.TransactionDate.ToString("g")
                }
            };

            transactionsViewList.Items.Add(listViewItem);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void withdrawBTN_Click(object sender, EventArgs e)
        {
            ToggleFastWithdrawButtons(true);
        }

        private void fastWithdraw_Back_Click(object sender, EventArgs e)
        {
            ToggleFastWithdrawButtons(false);
        }

        private void ToggleFastWithdrawButtons(bool visible)
        {
            fastWithdraw_Back.Visible = visible;
            fastWithdraw_100.Visible = visible;
            fastWithdraw_200.Visible = visible;
            fastWithdraw_500.Visible = visible;
            fastWithdraw_1000.Visible = visible;
            withdrawBTN.Visible = !visible;
        }

        private void FastWithdrawButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (decimal.TryParse(button.Tag.ToString(), out decimal amount))
                {
                    ProcessWithdrawal(amount);
                }
            }
        }

        private void ProcessWithdrawal(decimal amount)
        {
            if (accountBalance < amount)
            {
                ShowError("Insufficient Funds");
                return;
            }

            if (UpdateAccountBalance(amount) && RecordWithdrawal(amount))
            {
                MessageBox.Show("Cash Withdrawal Success!");
                LoadAccountBalance();
                LoadRecentTransactions();
            }
            else
            {
                ShowError("Cash Withdrawal Failed!");
            }
        }

        private bool RecordWithdrawal(decimal amount)
        {
            try
            {
                string connectionString = dbConnection.GetConnectionString();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO transfers (accountid, recipient_name, description, amount, transfer_datetime) " +
                                   "VALUES (@userId, @recipientName, @description, @amount, @transferDatetime)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@recipientName", "ATM");
                        command.Parameters.AddWithValue("@description", $"Withdrawal of {amount:C} from ATM");
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@transferDatetime", DateTime.Now);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                ShowError("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                ShowError("An unexpected error occurred: " + ex.Message);
                return false;
            }
        }

        private bool UpdateAccountBalance(decimal amount)
        {
            decimal newBalance = accountBalance - amount;
            try
            {
                string connectionString = dbConnection.GetConnectionString();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE accounts SET balance = @newBalance WHERE id = @userId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@newBalance", newBalance);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                ShowError("SQL Error: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                ShowError("An unexpected error occurred: " + ex.Message);
                return false;
            }
        }
    }
}
