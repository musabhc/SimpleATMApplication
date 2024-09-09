namespace SimpleATMApplication
{
    partial class LoginScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cardNumberEntryBox = new System.Windows.Forms.TextBox();
            this.confirmBTN = new System.Windows.Forms.Button();
            this.pinEntryBox = new System.Windows.Forms.TextBox();
            this.welcomeText = new System.Windows.Forms.Label();
            this.cardNumberText = new System.Windows.Forms.Label();
            this.cardPinText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cardNumberEntryBox
            // 
            this.cardNumberEntryBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNumberEntryBox.Location = new System.Drawing.Point(477, 328);
            this.cardNumberEntryBox.Name = "cardNumberEntryBox";
            this.cardNumberEntryBox.Size = new System.Drawing.Size(310, 26);
            this.cardNumberEntryBox.TabIndex = 0;
            this.cardNumberEntryBox.TextChanged += new System.EventHandler(this.cardNumberEntryBox_TextChange);
            // 
            // confirmBTN
            // 
            this.confirmBTN.Location = new System.Drawing.Point(590, 408);
            this.confirmBTN.Name = "confirmBTN";
            this.confirmBTN.Size = new System.Drawing.Size(84, 40);
            this.confirmBTN.TabIndex = 1;
            this.confirmBTN.Text = "CONFIRM";
            this.confirmBTN.UseVisualStyleBackColor = true;
            this.confirmBTN.Click += new System.EventHandler(this.confirmBTN_Click);
            // 
            // pinEntryBox
            // 
            this.pinEntryBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinEntryBox.Location = new System.Drawing.Point(477, 376);
            this.pinEntryBox.Name = "pinEntryBox";
            this.pinEntryBox.Size = new System.Drawing.Size(310, 26);
            this.pinEntryBox.TabIndex = 2;
            this.pinEntryBox.TextChanged += new System.EventHandler(this.pinEntryBox_TextChanged);
            // 
            // welcomeText
            // 
            this.welcomeText.AutoSize = true;
            this.welcomeText.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.welcomeText.Location = new System.Drawing.Point(548, 264);
            this.welcomeText.Name = "welcomeText";
            this.welcomeText.Size = new System.Drawing.Size(168, 37);
            this.welcomeText.TabIndex = 3;
            this.welcomeText.Text = "Welcome!";
            // 
            // cardNumberText
            // 
            this.cardNumberText.AutoSize = true;
            this.cardNumberText.BackColor = System.Drawing.Color.Transparent;
            this.cardNumberText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNumberText.Location = new System.Drawing.Point(474, 307);
            this.cardNumberText.Name = "cardNumberText";
            this.cardNumberText.Size = new System.Drawing.Size(102, 18);
            this.cardNumberText.TabIndex = 4;
            this.cardNumberText.Text = "Card Number";
            // 
            // cardPinText
            // 
            this.cardPinText.AutoSize = true;
            this.cardPinText.BackColor = System.Drawing.Color.Transparent;
            this.cardPinText.Font = new System.Drawing.Font("Arial", 12F);
            this.cardPinText.Location = new System.Drawing.Point(474, 357);
            this.cardPinText.Name = "cardPinText";
            this.cardPinText.Size = new System.Drawing.Size(70, 18);
            this.cardPinText.TabIndex = 5;
            this.cardPinText.Text = "Card Pin";
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.cardPinText);
            this.Controls.Add(this.cardNumberText);
            this.Controls.Add(this.welcomeText);
            this.Controls.Add(this.pinEntryBox);
            this.Controls.Add(this.confirmBTN);
            this.Controls.Add(this.cardNumberEntryBox);
            this.Name = "LoginScreen";
            this.Text = "Simple ATM Login";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.Resize += new System.EventHandler(this.LoginScreen_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cardNumberEntryBox;
        private System.Windows.Forms.Button confirmBTN;
        private System.Windows.Forms.TextBox pinEntryBox;
        private System.Windows.Forms.Label welcomeText;
        private System.Windows.Forms.Label cardNumberText;
        private System.Windows.Forms.Label cardPinText;
    }
}

