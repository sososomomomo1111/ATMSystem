namespace ATMSystem
{
    partial class SelectFunctionPage
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
            this.deposit = new System.Windows.Forms.Button();
            this.withdraw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmRest = new System.Windows.Forms.Button();
            this.fund = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.ownerFunction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deposit
            // 
            this.deposit.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.deposit.Location = new System.Drawing.Point(215, 105);
            this.deposit.Name = "deposit";
            this.deposit.Size = new System.Drawing.Size(143, 91);
            this.deposit.TabIndex = 0;
            this.deposit.Text = "預入";
            this.deposit.UseVisualStyleBackColor = true;
            this.deposit.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // withdraw
            // 
            this.withdraw.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.withdraw.Location = new System.Drawing.Point(413, 105);
            this.withdraw.Name = "withdraw";
            this.withdraw.Size = new System.Drawing.Size(143, 91);
            this.withdraw.TabIndex = 1;
            this.withdraw.Text = "引出";
            this.withdraw.UseVisualStyleBackColor = true;
            this.withdraw.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(279, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "何をしますか？";
            // 
            // confirmRest
            // 
            this.confirmRest.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.confirmRest.Location = new System.Drawing.Point(413, 220);
            this.confirmRest.Name = "confirmRest";
            this.confirmRest.Size = new System.Drawing.Size(143, 91);
            this.confirmRest.TabIndex = 4;
            this.confirmRest.Text = "残高確認";
            this.confirmRest.UseVisualStyleBackColor = true;
            this.confirmRest.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // fund
            // 
            this.fund.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.fund.Location = new System.Drawing.Point(215, 220);
            this.fund.Name = "fund";
            this.fund.Size = new System.Drawing.Size(143, 91);
            this.fund.TabIndex = 3;
            this.fund.Text = "振込";
            this.fund.UseVisualStyleBackColor = true;
            this.fund.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // register
            // 
            this.register.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.register.Location = new System.Drawing.Point(313, 347);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(143, 91);
            this.register.TabIndex = 5;
            this.register.Text = "記帳";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // ownerFunction
            // 
            this.ownerFunction.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ownerFunction.Location = new System.Drawing.Point(142, 380);
            this.ownerFunction.Name = "ownerFunction";
            this.ownerFunction.Size = new System.Drawing.Size(127, 31);
            this.ownerFunction.TabIndex = 6;
            this.ownerFunction.Text = "オーナー機能";
            this.ownerFunction.UseVisualStyleBackColor = true;
            this.ownerFunction.Click += new System.EventHandler(this.functionButton_Click);
            // 
            // SelectFunctionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ownerFunction);
            this.Controls.Add(this.register);
            this.Controls.Add(this.confirmRest);
            this.Controls.Add(this.fund);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.withdraw);
            this.Controls.Add(this.deposit);
            this.Name = "SelectFunctionPage";
            this.Text = "機能選択画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deposit;
        private System.Windows.Forms.Button withdraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmRest;
        private System.Windows.Forms.Button fund;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Button ownerFunction;
    }
}

