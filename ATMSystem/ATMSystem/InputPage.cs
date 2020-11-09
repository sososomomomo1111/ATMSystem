using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    public partial class InputPage : Form
    {
        public bool isCanceled = true;

        public bool charCorrect { get; set; }

        protected const int WAITTIME = 4;

        public InputPage()
        {
            InitializeComponent();
            note.Text = "";
        }

        public InputPage(string text,string exp) : this()
        {
            label1.Text = text;
            explain.Text = exp;
        }

        protected void label1_Click(object sender, EventArgs e)
        {

        }



        protected void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void confirmButton_Click(object sender, EventArgs e)
        {
            isCanceled = false;
            this.Close();
        }

        protected void judgeInputText(ref int num, int textLength)
        {
            charCorrect = true;
            var judgeText = textBox.Text.ToString();

            try
            {
                num = int.Parse(judgeText);
            }
            catch (FormatException)
            {
                charCorrect = false;
                for (int i = 0; i < WAITTIME; i++)
                {
                    note.Text = string.Format("数字以外の文字が入力されました。\n{0}秒後に機能選択画面に戻ります。", WAITTIME - i);
                    var t = Task.Delay(1000);
                    t.Wait();
                }
                this.Close();
            }
            catch (OverflowException)
            {

            }
            
            var digitsIsSeven = (judgeText.Length == textLength);
            note.Text = (charCorrect &= digitsIsSeven) ? "" : "桁数が間違っています。";//注意文変更
            textBox.Text = "";//textBoxクリア
        }


    }
}
