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
    public partial class ControlBillCountPage : Form
    {
        public bool isCanceled { set; get; } = true;
        public int Bill1000 { get; set; }
        public int Bill5000 { get; set; }
        public int Bill10000 { get; set; }
        int AddBill1000;
        int AddBill5000;
        int AddBill10000;
        bool bill1000IsCorrect;
        bool bill5000IsCorrect;
        bool bill10000IsCorrect;
        const int MAXCOUNT = 1000;
        const int MINCOUNT = 0;


        public ControlBillCountPage()
        {
            InitializeComponent();

        }

        public ControlBillCountPage(int num1k, int num5k, int num10k) : this()
        {
            textBox1.ForeColor = Color.Red;
            Bill1000 = num1k;
            Bill5000 = num5k;
            Bill10000 = num10k;
            bill1000IsCorrect = true;
            bill5000IsCorrect = true;
            bill10000IsCorrect = true;
            label11.Text = Bill1000 + "枚";
            label12.Text = Bill5000 + "枚";
            label13.Text = Bill10000 + "枚";
            label15.Text = "調整後紙幣枚数" + "\n" + (Bill1000 + AddBill1000) + "枚";
            label16.Text = "調整後紙幣枚数" + "\n" + (Bill5000 + AddBill5000) + "枚";
            label17.Text = "調整後紙幣枚数" + "\n" + (Bill10000 + AddBill10000) + "枚";
        }


        //完了ボタン
        private void button2_Click(object sender, EventArgs e)
        {
            Bill1000 += AddBill1000;
            Bill5000 += AddBill5000;
            Bill10000 += AddBill10000;
            isCanceled = false;

            //機能選択画面に戻る
            this.Close();
        }

        //キャンセルボタン
        private void button1_Click(object sender, EventArgs e)
        {
            //機能選択画面に戻る
            this.Close();
        }

        private void judgeButtonAvailable()//3つの入力どれかでもエラー起きたらエラー表示&ボタン不可能
        {
            if (bill1000IsCorrect && bill5000IsCorrect && bill10000IsCorrect)
            {
                label14.Visible = false;
                button2.Enabled = true;
            }
            else
            {
                label14.Visible = true;
                button2.Enabled = false;
            }
        }

        private void judgeLimit(int addCount, ref bool isCorrect)//枚数制限
        {
            if (addCount > MAXCOUNT)
            {
                label14.Text = "補充できる上限枚数は1000枚です";
                isCorrect = false;
            }
            else if (addCount < MINCOUNT)
            {
                label14.Text = "引き出すことができません";
                isCorrect = false;
            }
        }

        private void bill1000judge()
        {
            bill1000IsCorrect = true;

            try
            {
                AddBill1000 = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception exp)
            {
                if (exp is FormatException)
                {
                    label14.Text = "入力が正しくありません";
                }

                if (exp is OverflowException)
                {
                    label14.Text = "桁数をオーバーしています";
                    textBox1.Text = "";
                }
                bill1000IsCorrect = false;
            }
            if (bill1000IsCorrect) judgeLimit(Bill1000 + AddBill1000, ref bill1000IsCorrect);

            textBox1.ForeColor = (bill1000IsCorrect) ? Color.Black : Color.Red;
        }

        private void bill5000judge()
        {
            bill5000IsCorrect = true;

            try
            {
                AddBill5000 = Convert.ToInt32(textBox2.Text);
            }
            catch (Exception exp)
            {
                if (exp is FormatException)
                {
                    label14.Text = "入力が正しくありません";
                }

                if (exp is OverflowException)
                {
                    label14.Text = "桁数をオーバーしています";
                    textBox2.Text = "";
                }
                bill5000IsCorrect = false;
            }
            if (bill5000IsCorrect) judgeLimit(Bill5000 + AddBill5000, ref bill5000IsCorrect);

            textBox2.ForeColor = (bill5000IsCorrect) ? Color.Black : Color.Red;
        }

        private void bill10000judge()
        {
            bill10000IsCorrect = true;

            try
            {
                AddBill10000 = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception exp)
            {
                if (exp is FormatException)
                {
                    label14.Text = "入力が正しくありません";
                }

                if (exp is OverflowException)
                {
                    label14.Text = "桁数をオーバーしています";
                    textBox3.Text = "";
                }
                bill10000IsCorrect = false;
            }
            if (bill10000IsCorrect) judgeLimit(Bill10000 + AddBill10000, ref bill10000IsCorrect);

            textBox3.ForeColor = (bill10000IsCorrect) ? Color.Black : Color.Red;

        }

        private void textBox_TextChanged(object sender, EventArgs e)//共通で全部のtextboxに適用
        {
            label15.Text = "調整後紙幣枚数" + "\n" + (Bill1000 + AddBill1000) + "枚";
            label16.Text = "調整後紙幣枚数" + "\n" + (Bill5000 + AddBill5000) + "枚";
            label17.Text = "調整後紙幣枚数" + "\n" + (Bill10000 + AddBill10000) + "枚";

            bill1000judge();
            bill5000judge();
            bill10000judge();
            judgeButtonAvailable();

            label15.Text = "調整後紙幣枚数" + "\n" + (Bill1000 + AddBill1000) + "枚";
            label16.Text = "調整後紙幣枚数" + "\n" + (Bill5000 + AddBill5000) + "枚";
            label17.Text = "調整後紙幣枚数" + "\n" + (Bill10000 + AddBill10000) + "枚";
        }

        private void ControlBillCountPage_Shown(object sender, EventArgs e)
        {
            try
            {
                //シリアル通信の設定
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

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this.ActiveControl.GetType().Equals(typeof(System.Windows.Forms.TextBox)))
            {
                int str = serialPort1.ReadByte();
                string num = Convert.ToString((char)str);
                Invoke(new MethodInvoker(() => this.ActiveControl.Text = this.ActiveControl.Text + num));　//マイコンからの入力を選択されたテキストボックスに反映
            }
        }

        private void ControlBillCountPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
