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

        const int BILLLIMIT = 20;
        string[] ports = SerialPort.GetPortNames(); //ポート番号を取得

        public InputDepositAmountPage()
        {
            InitializeComponent();

        }
        private void InputDepositAmountPage_Shown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); //ポート番号を取得
            serialPort1.BaudRate = 115200;
            serialPort1.DataBits = 8;
            serialPort1.PortName = ports[0];
            serialPort1.Open();

            textBox1.Focus();

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            //一万円札
            var textBox1 = (System.Windows.Forms.TextBox)sender;
            var tenthousandbill = textBox1.Text.ToString();
            //五千円札
            var textBox2 = (System.Windows.Forms.TextBox)sender;
            var fivethousandbill = textBox2.Text.ToString();
            //千円札
            var textBox3 = (System.Windows.Forms.TextBox)sender;
            var onethousandbill = textBox3.Text.ToString();

            try
            {
                tenbills = int.Parse(tenthousandbill);
                fivebills = int.Parse(fivethousandbill);
                onebills = int.Parse(onethousandbill);
            }
            catch (FormatException)
            {
                note.Text = string.Format("数字を入力してください。");
                textBox1.Text = "";//textBox1クリア
                textBox2.Text = "";//textBox2クリア
                textBox3.Text = "";//textBox3クリア
            }
            catch (OverflowException) 
            {
                note.Text = string.Format("{0}枚以下を入力してください。", BILLLIMIT);
            }
           // if//20枚以上の判定

            textBox1.Text = "";//textBox1クリア
            textBox2.Text = "";//textBox2クリア
            textBox3.Text = "";//textBox3クリア
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
