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
    public partial class ConfirmFundPage : Form
    {
        public bool isCanceled { set; get; } = false;

        public ConfirmFundPage()
        {
            InitializeComponent();
        }

        public ConfirmFundPage(int amount,int newRest):this()
        {
            label3.Text = amount.ToString();
            label5.Text = newRest.ToString();
        }


        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            isCanceled = true;
            this.Close();
        }
    }

}
