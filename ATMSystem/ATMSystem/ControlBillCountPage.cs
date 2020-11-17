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
    public partial class ControlBillCountPage : Form
    {
        int Bill1000 = 500;
        int Bill5000 = 500;
        int Bill10000 = 500;
        int AddBill1000;
        int AddBill5000;
        int AddBill10000;

        public ControlBillCountPage()
        {
            InitializeComponent();
            label11.Text = Bill1000 + "枚";
            label12.Text = Bill5000 + "枚";
            label13.Text = Bill10000 + "枚";
            label15.Text = "調整後紙幣枚数" + "\n残り" + (1000 - Bill1000 - AddBill1000) + "枚";
            label16.Text = "調整後紙幣枚数" + "\n残り" + (1000 - Bill5000 - AddBill5000) + "枚";
            label17.Text = "調整後紙幣枚数" + "\n残り" + (1000 - Bill10000 - AddBill10000) + "枚";
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
            //機能選択画面に戻る
            //.Show();
            this.Close();
        }

        //キャンセルボタン
        private void button1_Click(object sender, EventArgs e)
        {
            //機能選択画面に戻る
            //.show();
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
            else if(Bill1000 + AddBill1000 < 0)
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
            AddBill1000 = 0;
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
            AddBill5000 = 0;
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
            AddBill10000 = 0;
        }
    }
}
