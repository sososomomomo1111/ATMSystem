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
      

        public ControlBillCountPage()
        {
            InitializeComponent();

        }

        public ControlBillCountPage(int num1k, int num5k, int num10k) : this()
        {
            Bill1000 = num1k;
            Bill5000 = num5k;
            Bill10000 = num10k;
            label11.Text = Bill1000 + "枚";
            label12.Text = Bill5000 + "枚";
            label13.Text = Bill10000 + "枚";
            label15.Text = "調整後紙幣枚数" + "\n" + (Bill1000 + AddBill1000) + "枚";
            label16.Text = "調整後紙幣枚数" + "\n" + (Bill5000 + AddBill5000) + "枚";
            label17.Text = "調整後紙幣枚数" + "\n" + (Bill10000 + AddBill10000) + "枚";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        //1000円入力テキストボックス
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label14.Visible = false;
            button2.Enabled = true;
            label15.Text = "調整後紙幣枚数" + "\n" + (Bill1000 + AddBill1000) + "枚";
            textBox1.ForeColor = Color.Black;

            try
            {
                AddBill1000 = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException)
            {
                label14.Text = "入力が正しくありません";
                label14.Visible = true;
                button2.Enabled = false;
                textBox1.ForeColor = Color.Red;
                return;
            }
            catch (OverflowException)
            {
                label14.Text = "桁数をオーバーしています";
                textBox1.Text = textBox2.Text = textBox3.Text = "";
                label14.Visible = true;
                button2.Enabled = false;
                textBox1.ForeColor = Color.Red;
            }


            if (Bill1000 + AddBill1000 > 1000)
            {
                label14.Text = "補充できる上限枚数は1000枚です";
                label14.Visible = true;
                button2.Enabled = false;
                textBox1.ForeColor = Color.Red;
            }
            else if (Bill1000 + AddBill1000 < 0)
            {
                label14.Text = "引き出すことができません";
                label14.Visible = true;
                button2.Enabled = false;
                textBox1.ForeColor = Color.Red;
            }
            else
            {
                label14.Visible = false;
            }

            label15.Text = "調整後紙幣枚数" + "\n" + (Bill1000 + AddBill1000) + "枚";
        }

        //5000円入力テキストボックス
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label14.Visible = false;
            button2.Enabled = true;
            label16.Text = "調整後紙幣枚数" + "\n" + (Bill5000 + AddBill5000) + "枚";
            textBox2.ForeColor = Color.Black;

            try
            {
                AddBill5000 = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException)
            {
                label14.Text = "入力が正しくありません";
                label14.Visible = true;
                button2.Enabled = false;
                textBox2.ForeColor = Color.Red;
                return;
            }
            catch (OverflowException)
            {
                label14.Text = "桁数をオーバーしています";
                textBox1.Text = textBox2.Text = textBox3.Text = "";
                label14.Visible = true;
                button2.Enabled = false;
                textBox2.ForeColor = Color.Red;
            }


            if (Bill5000 + AddBill5000 > 1000)
            {
                label14.Text = "補充できる上限枚数は1000枚です";
                label14.Visible = true;
                button2.Enabled = false;
                textBox2.ForeColor = Color.Red;
            }
            else if (Bill5000 + AddBill5000 < 0)
            {
                label14.Text = "引き出すことができません";
                label14.Visible = true;
                button2.Enabled = false;
                textBox2.ForeColor = Color.Red;
            }
            else
            {
                label14.Visible = false;
            }

            label16.Text = "調整後紙幣枚数" + "\n" + (Bill5000 + AddBill5000) + "枚";
          
        }

        //10000円入力テキストボックス
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label14.Visible = false;
            button2.Enabled = true;
            label17.Text = "調整後紙幣枚数" + "\n" + (Bill10000 + AddBill10000) + "枚";
            textBox3.ForeColor = Color.Black;

            try
            {
                AddBill10000 = Convert.ToInt32(textBox3.Text);
            }
            catch (FormatException)
            {
                label14.Text = "入力が正しくありません";
                label14.Visible = true;
                button2.Enabled = false;
                textBox3.ForeColor = Color.Red;
                return;
            }
            catch (OverflowException)
            {
                label14.Text = "桁数をオーバーしています";
                textBox1.Text = textBox2.Text = textBox3.Text = "";
                label14.Visible = true;
                button2.Enabled = false;
                textBox3.ForeColor = Color.Red;
            }


            if (Bill10000 + AddBill10000 > 1000)
            {
                label14.Text = "補充できる上限枚数は1000枚です";
                label14.Visible = true;
                button2.Enabled = false;
                textBox3.ForeColor = Color.Red;
            }
            else if (Bill10000 + AddBill10000 < 0)
            {
                label14.Text = "引き出すことができません";
                label14.Visible = true;
                button2.Enabled = false;
                textBox3.ForeColor = Color.Red;
            }
            else
            {
                label14.Visible = false;
            }

            label17.Text = "調整後紙幣枚数" + "\n" + (Bill10000 + AddBill10000) + "枚";
           
        }

        private void ControlBillCountPage_Shown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); //ポート番号を取得
            serialPort1.BaudRate = 115200;
            serialPort1.DataBits = 8;
            serialPort1.PortName = ports[0];
            serialPort1.Open();

            textBox1.Focus();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this.ActiveControl.GetType().Equals(typeof(System.Windows.Forms.TextBox)))
            {
                int str = serialPort1.ReadByte();
                string num = Convert.ToString((char)str);
                Invoke(new MethodInvoker(() => this.ActiveControl.Text = this.ActiveControl.Text + num));
            }
        }

        private void ControlBillCountPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
