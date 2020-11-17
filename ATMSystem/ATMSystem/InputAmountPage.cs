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
        public int amount { set; get; } = 0;
        string functionName = "deposit";
        const int AMOUNTLIMIT = 200000;
        const int BILLLIMIT = 20;



        public InputAmountPage(string str, string exp) : base(str, exp)
        {
            InitializeComponent();
        }

        public InputAmountPage(string str, string exp, string fn, int fee) : this(str, exp)
        {
            functionName = fn;
            string s = string.Format("※手数料{0}円かかります。", fee);
            if (functionName == "withdraw")
            {
                s += string.Format("\n※限度額{0}円を超える引き出しは出来ません。\n※", AMOUNTLIMIT);
            }
        }



        private bool checkBillCount()
        {
            return true;
        }

        protected override void confirmButton_Click(object sender, EventArgs e)
        {
            int am = 0;
            judgeInputText(ref am);
            amount = am;
            if (charCorrect) this.Close();
        }

        protected void judgeInputText(ref int num)
        {
            charCorrect = true;
            var judgeText = textBox.Text.ToString();

            try
            {
                num = int.Parse(judgeText);
            }
            catch (Exception exception)
            {
                charCorrect = false;
                if (exception is ArgumentNullException)
                {
                    for (int i = 0; i < WAITTIME; i++)
                    {
                        note.Text = string.Format("何も入力されませんでした。\n{0}秒後に機能選択画面に戻ります。", WAITTIME - i);
                        var t = Task.Delay(1000);
                        t.Wait();
                    }
                    this.Close();
                }
                if (exception is FormatException)
                {
                    for (int i = 0; i < WAITTIME; i++)
                    {
                        string noteStr = "数字以外の文字が入力されました。";
                        if (judgeText == "") noteStr = "入力されませんでした。";

                        note.Text = string.Format(noteStr + "\n{0}秒後に機能選択画面に戻ります。", WAITTIME - i);
                        var t = Task.Delay(1000);
                        t.Wait();
                    }
                    this.Close();
                }
                if (exception is OverflowException)
                {
                    note.Text = string.Format("桁数が多すぎます。");
                    textBox.Text = "";
                }

            }

            if (functionName == "withdraw" && charCorrect && num > AMOUNTLIMIT)
            {
                note.Text = string.Format("取引金額が限度額を超えています。");
                textBox.Text = "";
                charCorrect = false;
            }



        }

       
    }
}
