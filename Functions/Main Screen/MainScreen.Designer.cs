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
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fastWithdraw_100 = new System.Windows.Forms.Button();
            this.fastWithdraw_200 = new System.Windows.Forms.Button();
            this.fastWithdraw_500 = new System.Windows.Forms.Button();
            this.fastWithdraw_1000 = new System.Windows.Forms.Button();
            this.fastWithdraw_other = new System.Windows.Forms.Button();
            this.fastWithdraw_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // withdrawBTN
            // 
            this.withdrawBTN.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.withdrawBTN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.withdrawBTN.Location = new System.Drawing.Point(453, 260);
            this.withdrawBTN.Name = "withdrawBTN";
            this.withdrawBTN.Size = new System.Drawing.Size(131, 42);
            this.withdrawBTN.TabIndex = 0;
            this.withdrawBTN.Text = "Withdraw";
            this.withdrawBTN.UseVisualStyleBackColor = true;
            this.withdrawBTN.Click += new System.EventHandler(this.withdrawBTN_Click);
            // 
            // cashAvailabityText
            // 
            this.cashAvailabityText.AutoSize = true;
            this.cashAvailabityText.Font = new System.Drawing.Font("Bahnschrift", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cashAvailabityText.Location = new System.Drawing.Point(446, 201);
            this.cashAvailabityText.Name = "cashAvailabityText";
            this.cashAvailabityText.Size = new System.Drawing.Size(138, 39);
            this.cashAvailabityText.TabIndex = 1;
            this.cashAvailabityText.Text = "Balance:";
            // 
            // balanceShowText
            // 
            this.balanceShowText.AutoSize = true;
            this.balanceShowText.Font = new System.Drawing.Font("Bahnschrift Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.balanceShowText.Location = new System.Drawing.Point(587, 201);
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
            // fastWithdraw_100
            // 
            this.fastWithdraw_100.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fastWithdraw_100.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fastWithdraw_100.Location = new System.Drawing.Point(453, 266);
            this.fastWithdraw_100.Name = "fastWithdraw_100";
            this.fastWithdraw_100.Size = new System.Drawing.Size(96, 32);
            this.fastWithdraw_100.TabIndex = 11;
            this.fastWithdraw_100.Text = "100";
            this.fastWithdraw_100.UseVisualStyleBackColor = true;
            this.fastWithdraw_100.Visible = false;
            this.fastWithdraw_100.Click += new System.EventHandler(this.fastWithdraw_100_Click);
            // 
            // fastWithdraw_200
            // 
            this.fastWithdraw_200.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fastWithdraw_200.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fastWithdraw_200.Location = new System.Drawing.Point(453, 304);
            this.fastWithdraw_200.Name = "fastWithdraw_200";
            this.fastWithdraw_200.Size = new System.Drawing.Size(96, 32);
            this.fastWithdraw_200.TabIndex = 12;
            this.fastWithdraw_200.Text = "200";
            this.fastWithdraw_200.UseVisualStyleBackColor = true;
            this.fastWithdraw_200.Visible = false;
            this.fastWithdraw_200.Click += new System.EventHandler(this.fastWithdraw_200_Click);
            // 
            // fastWithdraw_500
            // 
            this.fastWithdraw_500.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fastWithdraw_500.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fastWithdraw_500.Location = new System.Drawing.Point(453, 342);
            this.fastWithdraw_500.Name = "fastWithdraw_500";
            this.fastWithdraw_500.Size = new System.Drawing.Size(96, 32);
            this.fastWithdraw_500.TabIndex = 14;
            this.fastWithdraw_500.Text = "500";
            this.fastWithdraw_500.UseVisualStyleBackColor = true;
            this.fastWithdraw_500.Visible = false;
            this.fastWithdraw_500.Click += new System.EventHandler(this.fastWithdraw_500_Click);
            // 
            // fastWithdraw_1000
            // 
            this.fastWithdraw_1000.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fastWithdraw_1000.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fastWithdraw_1000.Location = new System.Drawing.Point(560, 266);
            this.fastWithdraw_1000.Name = "fastWithdraw_1000";
            this.fastWithdraw_1000.Size = new System.Drawing.Size(96, 32);
            this.fastWithdraw_1000.TabIndex = 16;
            this.fastWithdraw_1000.Text = "1000";
            this.fastWithdraw_1000.UseVisualStyleBackColor = true;
            this.fastWithdraw_1000.Visible = false;
            this.fastWithdraw_1000.Click += new System.EventHandler(this.fastWithdraw_1000_Click);
            // 
            // fastWithdraw_other
            // 
            this.fastWithdraw_other.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fastWithdraw_other.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fastWithdraw_other.Location = new System.Drawing.Point(560, 304);
            this.fastWithdraw_other.Name = "fastWithdraw_other";
            this.fastWithdraw_other.Size = new System.Drawing.Size(96, 32);
            this.fastWithdraw_other.TabIndex = 17;
            this.fastWithdraw_other.Text = "Other";
            this.fastWithdraw_other.UseVisualStyleBackColor = true;
            this.fastWithdraw_other.Visible = false;
            this.fastWithdraw_other.Click += new System.EventHandler(this.fastWithdraw_other_Click);
            // 
            // fastWithdraw_Back
            // 
            this.fastWithdraw_Back.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fastWithdraw_Back.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fastWithdraw_Back.Location = new System.Drawing.Point(560, 342);
            this.fastWithdraw_Back.Name = "fastWithdraw_Back";
            this.fastWithdraw_Back.Size = new System.Drawing.Size(96, 32);
            this.fastWithdraw_Back.TabIndex = 18;
            this.fastWithdraw_Back.Text = "Back";
            this.fastWithdraw_Back.UseVisualStyleBackColor = true;
            this.fastWithdraw_Back.Visible = false;
            this.fastWithdraw_Back.Click += new System.EventHandler(this.fastWithdraw_Back_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.fastWithdraw_Back);
            this.Controls.Add(this.withdrawBTN);
            this.Controls.Add(this.fastWithdraw_other);
            this.Controls.Add(this.fastWithdraw_1000);
            this.Controls.Add(this.fastWithdraw_500);
            this.Controls.Add(this.fastWithdraw_200);
            this.Controls.Add(this.fastWithdraw_100);
            this.Controls.Add(this.transactionsViewList);
            this.Controls.Add(this.previousTransactionsText);
            this.Controls.Add(this.balanceShowText);
            this.Controls.Add(this.cashAvailabityText);
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
        private System.Windows.Forms.Button fastWithdraw_100;
        private System.Windows.Forms.Button fastWithdraw_200;
        private System.Windows.Forms.Button fastWithdraw_500;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.Button fastWithdraw_1000;
        private System.Windows.Forms.Button fastWithdraw_other;
        private System.Windows.Forms.Button fastWithdraw_Back;
    }
}