using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleATMApplication
{
    public partial class LoginScreen : Form
    {
        // Login info dictionary
        Dictionary<long, int> loginInfo = new Dictionary<long, int>();

        // Custom error messages
        const string onlyNumberErrorMessage = "Please enter only numbers.";
        const string inputNullErrorMessage = "Card number or pin code is uncorrect! Please check again!";
        const string databaseConnectionFailErrorMessage = "An error occurred while accessing the database.";

        //Custom Messages
        const string databaseConnectionSuccess = "Database accessed and data pulled successfully!";

        // Max Digit Numbers
        int maxPinDigitNumber = 4;
        int maxCardDigitNumber = 16;

        /* MongoDB Connection */

        const string connectionUri = "MongoDB Connection URL"; // Your MongoDB Connection URL
        const string databaseName = "Customers"; // Your Database Name
        const string collectionName = "Accounts"; // Your Collection Name

        // Main Function
        public LoginScreen()
        {
            ConnectDataBase();
            InitializeComponent();
        }

        // Database Connection
        private void ConnectDataBase()
        {
            try
            {
                // MongoDB Settings
                var settings = MongoClientSettings.FromConnectionString(connectionUri);
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);

                // Create MongoDB Client
                var client = new MongoClient(settings);

                // Select database
                var database = client.GetDatabase(databaseName);

                // Select Collection
                var collection = database.GetCollection<BsonDocument>(collectionName);

                // Get all documents
                var documents = collection.Find(new BsonDocument()).ToList();

                // Process every document
                foreach (var document in documents)
                {
                    
                    loginInfo.Add(document["cardNumber"].AsInt64, document["cardPin"].AsInt32);
                    Console.WriteLine(document.ToString());
                }

                MessageBox.Show(databaseConnectionSuccess);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show(databaseConnectionFailErrorMessage);
            }
        }
        

        // Check Card Number
        private void cardNumberEntryBox_TextChange(object sender, EventArgs e)
        {
            // Last location of curser for after remove char.
            int cursorPosition = cardNumberEntryBox.SelectionStart;

            // Max digit number change
            cardNumberEntryBox.MaxLength = maxCardDigitNumber;

            /* If user entry something except numbers, show an error box and remove last input.*/
            if (System.Text.RegularExpressions.Regex.IsMatch(cardNumberEntryBox.Text, "[^0-9]"))
            {
                MessageBox.Show(onlyNumberErrorMessage); // Error Box
                cardNumberEntryBox.Text = cardNumberEntryBox.Text.Remove(cardNumberEntryBox.Text.Length - 1); // Remove char
                cardNumberEntryBox.SelectionStart = cardNumberEntryBox.Text.Length; // Curser location set
            }
        }
        
        // Check Pin Text Box
        private void pinEntryBox_TextChanged(object sender, EventArgs e)
        {
            
            // Last location of curser for after remove char.
            int cursorPosition = pinEntryBox.SelectionStart;

            // Align the text in the center of textbox
            pinEntryBox.TextAlign = HorizontalAlignment.Center;

            // Assign the asterisk to be the password character.
            pinEntryBox.PasswordChar = '*';

            // Max digit number change
            pinEntryBox.MaxLength = maxPinDigitNumber;

            /* If user entry something except numbers, show an error box and remove last input.*/
            if (System.Text.RegularExpressions.Regex.IsMatch(pinEntryBox.Text, "[^0-9]"))
            {
                MessageBox.Show(onlyNumberErrorMessage); // Error Box
                pinEntryBox.Text = pinEntryBox.Text.Remove(pinEntryBox.Text.Length - 1); // Remove char
                pinEntryBox.SelectionStart = pinEntryBox.Text.Length; // Curser location set
            }

        }

        // Login info check
        private void confirmBTN_Click(object sender, EventArgs e)
        {
            bool loginSuccess = false;
            if(pinEntryBox.TextLength == maxPinDigitNumber && cardNumberEntryBox.TextLength == maxCardDigitNumber)
            {
                foreach(long cardNums in loginInfo.Keys)
                {
                    if(long.Parse(cardNumberEntryBox.Text) == cardNums)
                    {
                        if(int.Parse(pinEntryBox.Text) == loginInfo[cardNums])
                        {
                            // LOGIN SUCCESS
                            loginSuccess = true;
                            MessageBox.Show("Login Success");
                        }
                        else
                        {
                            LoginFailError();
                        }
                    }
                }
                if (!loginSuccess)
                {
                    LoginFailError();
                }
            }
            else
            {
                LoginFailError();
            }
        }

        // Login Fail Function
        private void LoginFailError()
        {
            MessageBox.Show(inputNullErrorMessage);
        }
    }
}
