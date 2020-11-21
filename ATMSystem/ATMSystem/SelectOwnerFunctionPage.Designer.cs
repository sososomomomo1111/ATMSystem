namespace ATMSystem
{
    partial class SelectOwnerFunctionPage
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.explain = new System.Windows.Forms.Label();
            this.confirmBillCount = new System.Windows.Forms.Button();
            this.controlBillCount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.cancelButton.Location = new System.Drawing.Point(12, 340);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(194, 88);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // explain
            // 
            this.explain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.explain.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.explain.Location = new System.Drawing.Point(75, 34);
            this.explain.Name = "explain";
            this.explain.Size = new System.Drawing.Size(652, 70);
            this.explain.TabIndex = 6;
            this.explain.Text = "label";
            this.explain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // confirmBillCount
            // 
            this.confirmBillCount.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.confirmBillCount.Location = new System.Drawing.Point(186, 107);
            this.confirmBillCount.Name = "confirmBillCount";
            this.confirmBillCount.Size = new System.Drawing.Size(432, 75);
            this.confirmBillCount.TabIndex = 7;
            this.confirmBillCount.Text = "紙幣枚数確認";
            this.confirmBillCount.UseVisualStyleBackColor = true;
            this.confirmBillCount.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // controlBillCount
            // 
            this.controlBillCount.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.controlBillCount.Location = new System.Drawing.Point(186, 232);
            this.controlBillCount.Name = "controlBillCount";
            this.controlBillCount.Size = new System.Drawing.Size(432, 75);
            this.controlBillCount.TabIndex = 8;
            this.controlBillCount.Text = "紙幣枚数調整";
            this.controlBillCount.UseVisualStyleBackColor = true;
            this.controlBillCount.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // SelectOwnerFunctionPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.controlBillCount);
            this.Controls.Add(this.confirmBillCount);
            this.Controls.Add(this.explain);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SelectOwnerFunctionPage";
            this.Text = "オーナー機能選択画面";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.Label explain;
        private System.Windows.Forms.Button confirmBillCount;
        private System.Windows.Forms.Button controlBillCount;
    }
}