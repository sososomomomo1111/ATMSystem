using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    public partial class InputAmountPage : ATMSystem.InputPage
    {
        int id;
        bool charError = false;

        public InputAmountPage(string str):base(str)
        {
            InitializeComponent();
        }

        protected override void confirmButton_Click(object sender, EventArgs e)
        {
            var judgeText = textBox.Text.ToString();

            try
            {
                id = int.Parse(judgeText);
            }
            catch (FormatException)
            {
                charError = true;
                note.Text = "数字以外の文字が入力されました。\n4秒後に機能選択画面に戻ります。";
                var t = Task.Delay(4000);
                t.Wait();
                this.Close();
            }
            var digitsIsSeven = (judgeText.Length == 7);
            note.Text = digitsIsSeven ? "" : "桁数が間違っています。";//注意文変更
            textBox.Text = "";//textBoxクリア
            if (digitsIsSeven && !charError)
                base.confirmButton_Click(sender, e);//OKなら
        }


    }
}
