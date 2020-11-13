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
    public partial class InputDepositAmountPage : Form
    {
        public int tenbills { set; get; } = 0;   //一万円札枚数
        public int fivebills { set; get; } = 0;  //五千円札枚数
        public int onebills { set; get; } = 0;   //千円札枚数

        const int BILLLIMIT = 20;

        public InputDepositAmountPage()
        {
            InitializeComponent();
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
    }
}
