using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SimpleATMApplication
{
    public class DatabaseConnection
    {
        static DatabaseConnection()
        {
            DotNetEnv.Env.Load();

            // Test for .env file loading
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Error: .env file not loaded or DB_CONNECTION_STRING not found.");
            }
            else
            {
                Console.WriteLine("Success: DB_CONNECTION_STRING loaded.");
            }
        }

        // Retrieve the connection string from environment variables
        public string GetConnectionString()
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string is not set.");
            }
            return connectionString;
        }

        const string databaseConnectionFailErrorMessage = "An error occurred while accessing the database.";

        // Method to verify login information and get user ID
        public (bool isSuccess, int userId) VerifyLoginAndGetUserId(long cardNumber, int pinCode)
        {
            try
            {
                string connectionString = GetConnectionString(); // Use GetConnectionString to get the connection string
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to check if the card number exists and matches the pin code
                    string query = "SELECT id FROM accounts WHERE cardnum = @cardNumber AND cardpin = @pinCode";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cardNumber", cardNumber);
                    cmd.Parameters.AddWithValue("@pinCode", pinCode);

                    // Execute the query and get the result
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int userId = Convert.ToInt32(result);
                        return (true, userId);
                    }
                    else
                    {
                        return (false, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show(databaseConnectionFailErrorMessage);
                return (false, 0);
            }
        }
    }
}
