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
            this.SuspendLayout();
            // 
            // cardNumberEntryBox
            // 
            this.cardNumberEntryBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNumberEntryBox.Location = new System.Drawing.Point(430, 275);
            this.cardNumberEntryBox.Name = "cardNumberEntryBox";
            this.cardNumberEntryBox.Size = new System.Drawing.Size(310, 26);
            this.cardNumberEntryBox.TabIndex = 0;
            this.cardNumberEntryBox.TextChanged += new System.EventHandler(this.cardNumberEntryBox_TextChange);
            // 
            // confirmBTN
            // 
            this.confirmBTN.Location = new System.Drawing.Point(543, 339);
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
            this.pinEntryBox.Location = new System.Drawing.Point(430, 307);
            this.pinEntryBox.Name = "pinEntryBox";
            this.pinEntryBox.Size = new System.Drawing.Size(310, 26);
            this.pinEntryBox.TabIndex = 2;
            this.pinEntryBox.TextChanged += new System.EventHandler(this.pinEntryBox_TextChanged);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pinEntryBox);
            this.Controls.Add(this.confirmBTN);
            this.Controls.Add(this.cardNumberEntryBox);
            this.Name = "LoginScreen";
            this.Text = "Simple ATM Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cardNumberEntryBox;
        private System.Windows.Forms.Button confirmBTN;
        private System.Windows.Forms.TextBox pinEntryBox;
    }
}

