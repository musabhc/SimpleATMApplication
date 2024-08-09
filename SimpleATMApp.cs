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

namespace SimpleATMApplication
{
    public partial class SimpleATMApp : Form
    {
        // Custom error messages
        string only_number_error = "Please enter only numbers.";
        
        // max digit numbers
        int maxPinDigitNumber = 4;
        int maxCardDigitNumber = 16;



        public SimpleATMApp()
        {
            InitializeComponent();
        }

        private void cardNumberEntryBox_TextChange(object sender, EventArgs e)
        {
            // Last location of curser for after remove char.
            int cursorPosition = cardNumberEntryBox.SelectionStart;

            // Max digit number change
            cardNumberEntryBox.MaxLength = maxCardDigitNumber;

            /* If user entry something except numbers, show an error box and remove last input.*/
            if (System.Text.RegularExpressions.Regex.IsMatch(cardNumberEntryBox.Text, "[^0-9]"))
            {
                MessageBox.Show(only_number_error); // Error Box
                cardNumberEntryBox.Text = cardNumberEntryBox.Text.Remove(cardNumberEntryBox.Text.Length - 1); // Remove char
                cardNumberEntryBox.SelectionStart = cardNumberEntryBox.Text.Length; // Curser location set
            }
        }
        
        private void pinEntryBox_TextChanged(object sender, EventArgs e)
        {
            
            // Last location of curser for after remove char.
            int cursorPosition = cardNumberEntryBox.SelectionStart;

            // Align the text in the center of textbox
            pinEntryBox.TextAlign = HorizontalAlignment.Center;

            // Assign the asterisk to be the password character.
            pinEntryBox.PasswordChar = '*';

            // Max digit number change
            pinEntryBox.MaxLength = maxPinDigitNumber;

            /* If user entry something except numbers, show an error box and remove last input.*/
            if (System.Text.RegularExpressions.Regex.IsMatch(cardNumberEntryBox.Text, "[^0-9]"))
            {
                MessageBox.Show(only_number_error); // Error Box
                cardNumberEntryBox.Text = cardNumberEntryBox.Text.Remove(cardNumberEntryBox.Text.Length - 1); // Remove char
                cardNumberEntryBox.SelectionStart = cardNumberEntryBox.Text.Length; // Curser location set
            }

        }

        private void confirmBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
