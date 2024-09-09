using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        decimal accountBalance;

        // List of transactions
        private List<TransferTransaction> _transactions = new List<TransferTransaction>();
        private readonly int _userId;
        private readonly DatabaseConnection _dbConnection = new DatabaseConnection();

        public MainScreen(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            AlignScreen();
            InitializeListView();
            LoadRecentTransactions();
            LoadBalance();
        }

        private void LoadRecentTransactions()
        {

            transactionsViewList.Items.Clear();

            try
            {
                string connectionString = _dbConnection.GetConnectionString();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT transferid, recipient_name, amount, transfer_datetime, description FROM transfers " +
                                   "WHERE accountid = @userId ORDER BY transfer_datetime DESC LIMIT 5";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", _userId);

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
                                AddTransaction(transaction);
                            }
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                MessageBox.Show("An error occurred while retrieving the balance from the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("An unexpected error occurred.");
            }
        }

        private void LoadBalance()
        {
            try
            {
                string connectionString = _dbConnection.GetConnectionString();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT balance FROM accounts WHERE id = @userId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", _userId);

                        var balance = command.ExecuteScalar();

                        if (balance != null)
                        {
                            accountBalance = Convert.ToDecimal(balance);
                            Console.WriteLine($"Balance: {accountBalance}");
                            balanceShowText.Text = accountBalance.ToString();
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                MessageBox.Show("An error occurred while retrieving the balance from the database.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("An unexpected error occurred.");
            }
        }

        private void AddTransaction(TransferTransaction transaction)
        {
            if (_transactions.Count >= 5)
            {
                _transactions.RemoveAt(0); // Remove the oldest transaction if the list exceeds 5
            }
            _transactions.Add(transaction);

            // Create a new ListViewItem for the transaction
            var listViewItem = new ListViewItem(transaction.Recipient);

            // Add subitems to the ListViewItem
            listViewItem.SubItems.Add(transaction.Description);
            listViewItem.SubItems.Add(transaction.Amount.ToString("C"));
            listViewItem.SubItems.Add(transaction.TransactionDate.ToString("g"));

            // Add the ListViewItem to the ListView
            transactionsViewList.Items.Add(listViewItem);
        }

        private void InitializeListView()
        {
            // Clear existing columns
            transactionsViewList.Columns.Clear();

            // Add columns
            transactionsViewList.Columns.Add("Recipient", 100);
            transactionsViewList.Columns.Add("Description", 125);
            transactionsViewList.Columns.Add("Amount", 100);
            transactionsViewList.Columns.Add("Datetime", 150);

            // Optionally set view to Details
            transactionsViewList.View = View.Details;
        }


        private void AlignScreen()
        {
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            this.Size = new Size(screenBounds.Width, screenBounds.Height);
            this.Location = new Point(0, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }

        private void withdrawBTN_Click(object sender, EventArgs e)
        {
            // Show fast withdraw buttons
            fastWithdraw_Back.Visible = true;
            fastWithdraw_100.Visible = true;
            fastWithdraw_200.Visible = true;
            fastWithdraw_500.Visible = true;
            fastWithdraw_1000.Visible = true;

            withdrawBTN.Visible = false;



        }

        private void fastWithdraw_Back_Click(object sender, EventArgs e)
        {
            fastWithdraw_Back.Visible = false;
            fastWithdraw_100.Visible = false;
            fastWithdraw_200.Visible = false;
            fastWithdraw_500.Visible = false;
            fastWithdraw_1000.Visible = false;

            withdrawBTN.Visible = true;


        }

        private void fastWithdraw_100_Click(object sender, EventArgs e)
        {
            withdrawProccess(100);
        }

        private void fastWithdraw_200_Click(object sender, EventArgs e)
        {
            withdrawProccess(200);
        }

        private void fastWithdraw_500_Click(object sender, EventArgs e)
        {
            withdrawProccess(500);
        }

        private void fastWithdraw_1000_Click(object sender, EventArgs e)
        {
            withdrawProccess(1000);
        }

        private void fastWithdraw_other_Click(object sender, EventArgs e)
        {

        }

        private void withdrawProccess(decimal amount)
        {
            if (accountBalance < amount)
            {
                MessageBox.Show("Insufficient Funds");
            }
            else
            {
                MessageBox.Show("Cash Withdrawal in Progress");
                if (UpdateBalanceDB(amount) && InsertWithdrawDB(amount))
                {
                    MessageBox.Show("Cash Withdrawal Success!");
                    LoadBalance();
                    LoadRecentTransactions();
                }
                else
                {
                    MessageBox.Show("Cash Withdrawal Failed!");
                }
            }
        }

        private bool InsertWithdrawDB(decimal amount)
        {
            try
            {
                string connectionString = _dbConnection.GetConnectionString();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO transfers (accountid, recipient_name, description, amount, transfer_datetime) " +
                                   "VALUES (@userId, @recipientName, @description, @amount, @transferDatetime)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", _userId);
                        command.Parameters.AddWithValue("@recipientName", "ATM");
                        command.Parameters.AddWithValue("@description", $"Withdrawal of {amount:C} from ATM");
                        command.Parameters.AddWithValue("@amount", amount);
                        command.Parameters.AddWithValue("@transferDatetime", DateTime.Now);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Transaction inserted successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert transaction.");
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                MessageBox.Show("An error occurred while inserting the transaction into the database.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("An unexpected error occurred.");
                return false;
            }
            
        }

        private bool UpdateBalanceDB(decimal amount) 
        {
            decimal newBalance = accountBalance - amount;
            try
            {
                string connectionString = _dbConnection.GetConnectionString();
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE accounts SET balance = @newBalance WHERE id = @userId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", _userId);
                        command.Parameters.AddWithValue("@newBalance", newBalance);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Transaction inserted successfully.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Failed to insert transaction.");
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                MessageBox.Show("An error occurred while inserting the transaction into the database.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("An unexpected error occurred.");
                return false;
            }
        }
    }
}
