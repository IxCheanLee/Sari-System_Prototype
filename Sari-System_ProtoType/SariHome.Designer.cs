namespace Sari_System_ProtoType
{
    partial class SariHome
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SoldToday = new System.Windows.Forms.Label();
            this.EarnedToday = new System.Windows.Forms.Label();
            this.NeedRestock = new System.Windows.Forms.Label();
            this.TotEarned = new System.Windows.Forms.Label();
            this.TotSold = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quick Reports";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Items Sold Today";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(297, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount Earned Today";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(646, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Items Need Re-Stocking";
            // 
            // SoldToday
            // 
            this.SoldToday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SoldToday.AutoSize = true;
            this.SoldToday.Font = new System.Drawing.Font("Modern No. 20", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoldToday.Location = new System.Drawing.Point(24, 102);
            this.SoldToday.Name = "SoldToday";
            this.SoldToday.Size = new System.Drawing.Size(58, 65);
            this.SoldToday.TabIndex = 4;
            this.SoldToday.Text = "0";
            this.SoldToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EarnedToday
            // 
            this.EarnedToday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EarnedToday.AutoSize = true;
            this.EarnedToday.Font = new System.Drawing.Font("Modern No. 20", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EarnedToday.Location = new System.Drawing.Point(322, 102);
            this.EarnedToday.Name = "EarnedToday";
            this.EarnedToday.Size = new System.Drawing.Size(58, 65);
            this.EarnedToday.TabIndex = 5;
            this.EarnedToday.Text = "0";
            this.EarnedToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NeedRestock
            // 
            this.NeedRestock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NeedRestock.AutoSize = true;
            this.NeedRestock.Font = new System.Drawing.Font("Modern No. 20", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NeedRestock.Location = new System.Drawing.Point(656, 102);
            this.NeedRestock.Name = "NeedRestock";
            this.NeedRestock.Size = new System.Drawing.Size(58, 65);
            this.NeedRestock.TabIndex = 6;
            this.NeedRestock.Text = "0";
            this.NeedRestock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotEarned
            // 
            this.TotEarned.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TotEarned.AutoSize = true;
            this.TotEarned.Font = new System.Drawing.Font("Modern No. 20", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotEarned.Location = new System.Drawing.Point(503, 268);
            this.TotEarned.Name = "TotEarned";
            this.TotEarned.Size = new System.Drawing.Size(58, 65);
            this.TotEarned.TabIndex = 10;
            this.TotEarned.Text = "0";
            this.TotEarned.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotSold
            // 
            this.TotSold.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TotSold.AutoSize = true;
            this.TotSold.Font = new System.Drawing.Font("Modern No. 20", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotSold.Location = new System.Drawing.Point(61, 268);
            this.TotSold.Name = "TotSold";
            this.TotSold.Size = new System.Drawing.Size(58, 65);
            this.TotSold.TabIndex = 9;
            this.TotSold.Text = "0";
            this.TotSold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(492, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(277, 29);
            this.label7.TabIndex = 8;
            this.label7.Text = "Total Amount Earned";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(52, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(211, 29);
            this.label8.TabIndex = 7;
            this.label8.Text = "Total Items Sold";
            // 
            // SariHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(212)))), ((int)(((byte)(202)))));
            this.ClientSize = new System.Drawing.Size(990, 439);
            this.Controls.Add(this.TotEarned);
            this.Controls.Add(this.TotSold);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.NeedRestock);
            this.Controls.Add(this.EarnedToday);
            this.Controls.Add(this.SoldToday);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SariHome";
            this.Text = "Sari Home";
            this.Load += new System.EventHandler(this.SariHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SoldToday;
        private System.Windows.Forms.Label EarnedToday;
        private System.Windows.Forms.Label NeedRestock;
        private System.Windows.Forms.Label TotEarned;
        private System.Windows.Forms.Label TotSold;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}