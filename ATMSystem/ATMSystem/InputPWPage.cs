using System;
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
    public partial class InputPWPage : InputPage
    {

        public int id { get; set; }

        const int TEXTLENGTH = 4;


        public InputPWPage(string str) : base(str)
        {
            InitializeComponent();
        }

        protected override void confirmButton_Click(object sender, EventArgs e)
        {

            int idd = 0;
            judgeInputText(ref idd, TEXTLENGTH);
            id = idd;
            base.confirmButton_Click(sender, e);

            //charCorrect = true;
            //var judgeText = textBox.Text.ToString();

            //try
            //{
            //    id = int.Parse(judgeText);
            //}
            //catch (FormatException)
            //{
            //    charCorrect = false;
            //    note.Text = "数字以外の文字が入力されました。\n4秒後に機能選択画面に戻ります。";
            //    var t = Task.Delay(4000);
            //    t.Wait();
            //    this.Close();
            //}
            //var digitsIsSeven = (judgeText.Length == 4);
            //note.Text = (charCorrect &= digitsIsSeven) ? "" : "桁数が間違っています。";//注意文変更
            //textBox.Text = "";//textBoxクリア
            //if (charCorrect)
            //    base.confirmButton_Click(sender, e);//OKなら
        }
    }
}
