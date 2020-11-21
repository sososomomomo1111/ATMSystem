using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ATMSystem
{
    public partial class InputDepositAmountPage : Form
    {
        public int tenbills { set; get; } = 0;   //一万円札枚数
        public int fivebills { set; get; } = 0;  //五千円札枚数
        public int onebills { set; get; } = 0;   //千円札枚数

        const int BILLLIMIT = 20;                //預入限度枚数、各種

        public bool isCanceled = true;           //true:isCancel()を実行  false:isCancel()を実行しない

        public bool charCorrect { get; set; }

        protected const int WAITTIME = 4;

        public InputDepositAmountPage()
        {
            InitializeComponent();
            note.Text = "";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            //一万円札
            //var textBox1 = (System.Windows.Forms.TextBox)sender;
            var tenthousandbill = textBox1.Text.ToString();
            //五千円札
            //var textBox2 = (System.Windows.Forms.TextBox)sender;
            var fivethousandbill = textBox2.Text.ToString();
            //千円札
            //var textBox3 = (System.Windows.Forms.TextBox)sender;
            var onethousandbill = textBox3.Text.ToString();

            charCorrect = true;
            isCanceled = false;

            try
            {
                tenbills = int.Parse(tenthousandbill);
                fivebills = int.Parse(fivethousandbill);
                onebills = int.Parse(onethousandbill);
            }
            catch (FormatException)
            {
                isCanceled = true;
                charCorrect = false;
                for (int i = 0; i < WAITTIME; i++)
                {
                    string noteStr = "数字以外の文字が入力されました。";
                    if (tenthousandbill == "" || fivethousandbill == "" || onethousandbill == "")
                        noteStr = "入力されていない項目が存在します。";

                    note.Text = string.Format(noteStr + "\n{0}秒後に機能選択画面に戻ります。", WAITTIME - i);
                    var t = Task.Delay(1000);
                    t.Wait();
                }
                this.Close();
            }
            catch (OverflowException)
            {
                charCorrect = false;
                note.Text = string.Format("{0}枚以下を入力してください。", BILLLIMIT);
                textBox1.Text = "";//textBox1クリア
                textBox2.Text = "";//textBox2クリア
                textBox3.Text = "";//textBox3クリア
            }

            //預入限度紙幣枚数の判定
            if (charCorrect&& tenbills > BILLLIMIT || fivebills > BILLLIMIT || onebills > BILLLIMIT)
            {
                charCorrect = false;
                note.Text = string.Format("{0}枚以下を入力してください。", BILLLIMIT);
                textBox1.Text = "0";//textBox1クリア
                textBox2.Text = "0";//textBox2クリア
                textBox3.Text = "0";//textBox3クリア
            }

            if(charCorrect &&tenbills==0 && fivebills == 0 && onebills == 0)
            {
                charCorrect = false;
                note.Text = string.Format("すべての紙幣枚数が0です。");
                textBox1.Text = "0";//textBox1クリア
                textBox2.Text = "0";//textBox2クリア
                textBox3.Text = "0";//textBox3クリア
            }

            if(isCanceled ||(!isCanceled && charCorrect))
            {
                this.Close();
            }


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputDepositAmountPage_Shown(object sender, EventArgs e)
        {
            try
            {
                string[] ports = SerialPort.GetPortNames(); //ポート番号を取得
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.PortName = ports[0];
                serialPort1.Open();
            }
            catch (IndexOutOfRangeException)
            {

            }

            textBox1.Focus();
        }
        protected void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this.ActiveControl.GetType().Equals(typeof(System.Windows.Forms.TextBox)))
            {
                int str = serialPort1.ReadByte();
                string num = Convert.ToString((char)str);
                Invoke(new MethodInvoker(() => this.ActiveControl.Text = this.ActiveControl.Text + num));
            }
        }

        private void InputPage_FormClosing_1(object sender, FormClosingEventArgs e)
        {

        }
    }
}
