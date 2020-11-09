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
        int amount=0;
        bool charError = false;
        string functionName="deposit";
        const int AMOUNTLIMIT = 200000;
        const int BILLLIMIT = 20;



        public InputAmountPage(string str,string exp):base(str,exp)
        {
            InitializeComponent();
        }

        public InputAmountPage(string str,string exp,string fn) : this(str,exp)
        {
            functionName = fn;

        }

    

        private bool checkBillCount()
        {
            return true;
        }

        protected override void confirmButton_Click(object sender, EventArgs e)
        {
            //預入では各種20枚が限度
            //引出では20万が限度
            var textBox = (System.Windows.Forms.TextBox)sender;
            var judgeText = textBox.Text.ToString();
            //var digits = (judgeText.Length == 7);

            try
            {
                amount = int.Parse(judgeText);
            }
            catch (FormatException)
            {
                note.Text = string.Format("数字を入力してください。");
            }

            switch (functionName)
            {
                case "deposit":
                    break;
                case "withdraw":
                    //20万まで
                    note.Text = string.Format("。");
                    break;
                case "fund":
                    break;
                default:
                    break;
            }

            //confirmButton.Enabled = digits;//7桁でボタンを押せるように
          //  note.Text = (confirmButton.Enabled = digits) ? "" : "桁数が間違っています。";

            base.confirmButton_Click(sender, e);
        }


    }
}
