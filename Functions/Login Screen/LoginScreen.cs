using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleATMApplication
{
    public partial class LoginScreen : Form
    {
        // Custom error messages
        const string onlyNumberErrorMessage = "Please enter only numbers.";
        const string inputNullErrorMessage = "Card number or pin code is incorrect! Please check again!";
        const string loginSuccessMessage = "Login Success";
        const string loginFailMessage = "Login failed. Card number or PIN is incorrect.";

        // Max Digit Numbers
        int maxPinDigitNumber = 4;
        int maxCardDigitNumber = 16;

        // Main Function
        public LoginScreen()
        {
            InitializeComponent();
        }

        // Check Card Number
        private void cardNumberEntryBox_TextChange(object sender, EventArgs e)
        {
            // Last location of cursor for after remove char.
            int cursorPosition = cardNumberEntryBox.SelectionStart;

            // Max digit number change
            cardNumberEntryBox.MaxLength = maxCardDigitNumber;

            /* If user entry something except numbers, show an error box and remove last input.*/
            if (System.Text.RegularExpressions.Regex.IsMatch(cardNumberEntryBox.Text, "[^0-9]"))
            {
                MessageBox.Show(onlyNumberErrorMessage); // Error Box
                cardNumberEntryBox.Text = cardNumberEntryBox.Text.Remove(cardNumberEntryBox.Text.Length - 1); // Remove char
                cardNumberEntryBox.SelectionStart = cardNumberEntryBox.Text.Length; // Cursor location set
            }
        }

        // Check Pin Text Box
        private void pinEntryBox_TextChanged(object sender, EventArgs e)
        {
            // Last location of cursor for after remove char.
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
                pinEntryBox.SelectionStart = pinEntryBox.Text.Length; // Cursor location set
            }
        }

        // Login info check
        private void confirmBTN_Click(object sender, EventArgs e)
        {
            if (pinEntryBox.TextLength == maxPinDigitNumber && cardNumberEntryBox.TextLength == maxCardDigitNumber)
            {
                long cardNumber = long.Parse(cardNumberEntryBox.Text);
                int pinCode = int.Parse(pinEntryBox.Text);

                DatabaseConnection dbConnection = new DatabaseConnection();
                var (loginSuccess, userId) = dbConnection.VerifyLoginAndGetUserId(cardNumber, pinCode);

                if (loginSuccess)
                {
                    MessageBox.Show(loginSuccessMessage);

                    // Create and show MainScreen form with user ID
                    MainScreen mainScreen = new MainScreen(userId);
                    mainScreen.Show();

                    // Close LoginScreen form
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(loginFailMessage);
                }
            }
            else
            {
                MessageBox.Show(inputNullErrorMessage);
            }
        }


        // Login Screen Resize
        private void LoginScreen_Resize(object sender, EventArgs e)
        {
            LoginScreenAlign();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            LoginScreenAlign();
        }

        private void LoginScreenAlign()
        {
            // Get the screen resolution
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            
            // Set the form size to match the screen resolution
            this.Size = new Size(screenBounds.Width, screenBounds.Height);
            this.Location = new Point(0, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

            // Form width and height 
            this.Size = new Size(1920, 1080);
            this.MaximumSize = new Size(1920, 1080);
            this.MinimumSize = new Size(1280, 720);
            int loginScreenWidth = this.ClientSize.Width;
            int loginScreenHeight = this.ClientSize.Height;

            /* Center elements */

            // Text Elements Left
            welcomeText.Left = (loginScreenWidth - welcomeText.Width) / 2;
            cardNumberText.Left = (loginScreenWidth - cardNumberEntryBox.Width) / 2;
            cardPinText.Left = (loginScreenWidth - pinEntryBox.Width) / 2;

            //Text Box Left
            cardNumberEntryBox.Left = (loginScreenWidth - cardNumberEntryBox.Width) / 2;
            pinEntryBox.Left = (loginScreenWidth - pinEntryBox.Width) / 2;
            confirmBTN.Left = (loginScreenWidth - confirmBTN.Width) / 2;

            //Text Elements Top
            welcomeText.Top = (loginScreenHeight / 2) - (cardNumberEntryBox.Height + confirmBTN.Height);
            cardNumberText.Top = (loginScreenHeight / 2) - (cardNumberEntryBox.Height + confirmBTN.Height) + 30;
            cardPinText.Top = (loginScreenHeight / 2) - (cardNumberEntryBox.Height + confirmBTN.Height) + 80;

            // Text Box Top
            cardNumberEntryBox.Top = welcomeText.Top + welcomeText.Height + 15;
            pinEntryBox.Top = cardNumberEntryBox.Top + cardNumberEntryBox.Height + 20;
            confirmBTN.Top = pinEntryBox.Top + pinEntryBox.Height + 20;
        }
    }
}
