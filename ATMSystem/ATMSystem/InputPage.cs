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
using System.IO.Ports;

namespace ATMSystem
{
    public partial class InputPage : Form
    {
        public bool isCanceled { get; set; } = true;

        public bool charCorrect { get; set; }

        protected const int WAITTIME = 4;
        protected bool digitsIsCorrect;


        public InputPage()
        {
            InitializeComponent();
            note.Text = "";
            this.ActiveControl = textBox;
        }

        public InputPage(string text,string exp) : this()
        {
            label1.Text = text;
            explain.Text = exp;
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void confirmButton_Click(object sender, EventArgs e)
        {
            if (digitsIsCorrect)
            {
                isCanceled = false;
                this.Close();
            }
        }

        protected void judgeInputText(ref int num, int textLength)
        {
            charCorrect = true;
            var judgeText = textBox.Text.ToString();

            try
            {
                   num = int.Parse(judgeText);
            }
            catch(Exception exception)
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

                        note.Text = string.Format(noteStr+"\n{0}秒後に機能選択画面に戻ります。", WAITTIME - i);
                        var t = Task.Delay(1000);
                        t.Wait();
                    }
                    this.Close();
                }
                if(exception is OverflowException)
                {
                    ;
                }
              
            }
                   
             digitsIsCorrect = (judgeText.Length == textLength);
            //note.Text = (charCorrect &=digitsIsCorrect) ? "" : "桁数が間違っています。";//注意文変更
            note.Text = digitsIsCorrect ? "" : "桁数が間違っています。";//注意文変更
            textBox.Text = "";//textBoxクリア
        }

        protected void judgeInputText(ref long num, int textLength)//オーナー機能用
        {
            charCorrect = true;
            var judgeText = textBox.Text.ToString();

            try
            {
                num = long.Parse(judgeText);
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
                    ;
                }

            }

            digitsIsCorrect = (judgeText.Length == textLength);
            //note.Text = (charCorrect &=digitsIsCorrect) ? "" : "桁数が間違っています。";//注意文変更
            note.Text = digitsIsCorrect ? "" : "桁数が間違っています。";//注意文変更
            textBox.Text = "";//textBoxクリア
        }
        private void InputPage_Shown(object sender, EventArgs e)
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
            textBox.Focus();
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int str = serialPort1.ReadByte();
            string num = Convert.ToString((char)str);
            Invoke(new MethodInvoker(() => textBox.Text = textBox.Text + num));

        }

        private void InputPage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }

}



