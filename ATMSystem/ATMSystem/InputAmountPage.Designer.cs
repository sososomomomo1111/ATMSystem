namespace ATMSystem
{
    partial class InputAmountPage
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
       

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.Note2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            // 
            // Note2
            // 
            this.Note2.AutoSize = true;
            this.Note2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note2.Location = new System.Drawing.Point(12, 228);
            this.Note2.Name = "Note2";
            this.Note2.Size = new System.Drawing.Size(0, 19);
            this.Note2.TabIndex = 6;
            // 
            // InputAmountPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Note2);
            this.Name = "InputAmountPage";
            this.Text = "金額入力画面";
            this.Controls.SetChildIndex(this.confirmButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.textBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.note, 0);
            this.Controls.SetChildIndex(this.explain, 0);
            this.Controls.SetChildIndex(this.Note2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Note2;
    }
}
