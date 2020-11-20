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
    public partial class ConfirmBillPage : Form
    {
        public int Bill1000 { get; set; }
        public int Bill5000 { get; set; }
        public int Bill10000 { get; set; }

        public ConfirmBillPage()
        {
            InitializeComponent();
        }

        protected virtual void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmBillPage_Shown(object sender, EventArgs e)
        {
            //紙幣枚数を表示
            label2.Text = Convert.ToString(Bill1000);
            label3.Text = Convert.ToString(Bill5000);
            label4.Text = Convert.ToString(Bill10000);
        }
    }
    }
}
