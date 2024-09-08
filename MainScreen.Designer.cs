namespace SimpleATMApplication
{
    partial class MainScreen
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
            this.withdrawBTN = new System.Windows.Forms.Button();
            this.cashAvailabityText = new System.Windows.Forms.Label();
            this.balanceShowText = new System.Windows.Forms.Label();
            this.previousTransactionsText = new System.Windows.Forms.Label();
            this.transactionsViewList = new System.Windows.Forms.ListView();
            this.recipient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // withdrawBTN
            // 
            this.withdrawBTN.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.withdrawBTN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.withdrawBTN.Location = new System.Drawing.Point(453, 214);
            this.withdrawBTN.Name = "withdrawBTN";
            this.withdrawBTN.Size = new System.Drawing.Size(131, 42);
            this.withdrawBTN.TabIndex = 0;
            this.withdrawBTN.Text = "Withdraw";
            this.withdrawBTN.UseVisualStyleBackColor = true;
            // 
            // cashAvailabityText
            // 
            this.cashAvailabityText.AutoSize = true;
            this.cashAvailabityText.Font = new System.Drawing.Font("Bahnschrift", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cashAvailabityText.Location = new System.Drawing.Point(446, 162);
            this.cashAvailabityText.Name = "cashAvailabityText";
            this.cashAvailabityText.Size = new System.Drawing.Size(138, 39);
            this.cashAvailabityText.TabIndex = 1;
            this.cashAvailabityText.Text = "Balance:";
            // 
            // balanceShowText
            // 
            this.balanceShowText.AutoSize = true;
            this.balanceShowText.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.balanceShowText.Location = new System.Drawing.Point(587, 162);
            this.balanceShowText.Name = "balanceShowText";
            this.balanceShowText.Size = new System.Drawing.Size(69, 39);
            this.balanceShowText.TabIndex = 2;
            this.balanceShowText.Text = "xxxx";
            // 
            // previousTransactionsText
            // 
            this.previousTransactionsText.AutoSize = true;
            this.previousTransactionsText.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.previousTransactionsText.Location = new System.Drawing.Point(448, 383);
            this.previousTransactionsText.Name = "previousTransactionsText";
            this.previousTransactionsText.Size = new System.Drawing.Size(269, 29);
            this.previousTransactionsText.TabIndex = 3;
            this.previousTransactionsText.Text = "Previous Transactions";
            // 
            // transactionsViewList
            // 
            this.transactionsViewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.recipient,
            this.description,
            this.amount,
            this.time});
            this.transactionsViewList.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.transactionsViewList.HideSelection = false;
            this.transactionsViewList.Location = new System.Drawing.Point(453, 425);
            this.transactionsViewList.Name = "transactionsViewList";
            this.transactionsViewList.Scrollable = false;
            this.transactionsViewList.Size = new System.Drawing.Size(475, 125);
            this.transactionsViewList.TabIndex = 9;
            this.transactionsViewList.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 32);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(453, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(453, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 32);
            this.button3.TabIndex = 12;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(560, 262);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 32);
            this.button5.TabIndex = 14;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(586, 214);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(131, 42);
            this.button4.TabIndex = 15;
            this.button4.Text = "Withdraw";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.transactionsViewList);
            this.Controls.Add(this.previousTransactionsText);
            this.Controls.Add(this.balanceShowText);
            this.Controls.Add(this.cashAvailabityText);
            this.Controls.Add(this.withdrawBTN);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button withdrawBTN;
        private System.Windows.Forms.Label cashAvailabityText;
        private System.Windows.Forms.Label balanceShowText;
        private System.Windows.Forms.Label previousTransactionsText;
        private System.Windows.Forms.ListView transactionsViewList;
        private System.Windows.Forms.ColumnHeader recipient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.Button button4;
    }
}