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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(282, 276);
            this.label1.Size = new System.Drawing.Size(329, 146);
            // 
            // explain
            // 
            this.explain.Location = new System.Drawing.Point(410, 123);
            this.explain.Size = new System.Drawing.Size(748, 109);
            // 
            // InputAmountPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1353, 680);
            this.Name = "InputAmountPage";
            this.Text = "金額入力画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
