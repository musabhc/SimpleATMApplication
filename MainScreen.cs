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
        }

        private void LoadRecentTransactions()
        {
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
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("An error occurred while loading transactions.");
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
    }
}
