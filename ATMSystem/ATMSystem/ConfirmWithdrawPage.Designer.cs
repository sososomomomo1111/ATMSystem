namespace ATMSystem
{
    partial class ConfirmWithdrawPage
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
            this.label4 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rest = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 70);
            this.label1.TabIndex = 8;
            this.label1.Text = "取引内容を確認してください";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(0, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(800, 30);
            this.label4.TabIndex = 14;
            this.label4.Text = "引き出し金額";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // amount
            // 
            this.amount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.amount.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.amount.Location = new System.Drawing.Point(300, 120);
            this.amount.Margin = new System.Windows.Forms.Padding(0);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(200, 50);
            this.amount.TabIndex = 15;
            this.amount.Text = "\\99,999,999";
            this.amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(0, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(800, 30);
            this.label2.TabIndex = 16;
            this.label2.Text = "手数料 \\220";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rest
            // 
            this.rest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rest.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rest.Location = new System.Drawing.Point(300, 260);
            this.rest.Margin = new System.Windows.Forms.Padding(0);
            this.rest.Name = "rest";
            this.rest.Size = new System.Drawing.Size(200, 50);
            this.rest.TabIndex = 17;
            this.rest.Text = "\\99,999,999";
            this.rest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(0, 230);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(800, 30);
            this.label6.TabIndex = 18;
            this.label6.Text = "引き出し後残高";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirmButton
            // 
            this.confirmButton.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.confirmButton.Location = new System.Drawing.Point(636, 366);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(5);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Padding = new System.Windows.Forms.Padding(5);
            this.confirmButton.Size = new System.Drawing.Size(150, 70);
            this.confirmButton.TabIndex = 19;
            this.confirmButton.Text = "確認";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(9, 355);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(280, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "確認ボタンを押すと最初の画面に戻ります";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfirmWithdrawPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "ConfirmWithdrawPage";
            this.Text = "引き出し確認画面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label rest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label label7;
    }
}