﻿namespace ATMSystem
{
    partial class InputIDPage
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
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // note
            // 
            this.note.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.note.Size = new System.Drawing.Size(625, 237);
            // 
            // InputIDPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 675);
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.Name = "InputIDPage";
            this.Text = "ID入力画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}