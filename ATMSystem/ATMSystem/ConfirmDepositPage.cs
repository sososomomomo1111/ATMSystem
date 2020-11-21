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
    public partial class ConfirmDepositPage : Form
    {
        public ConfirmDepositPage()
        {
            InitializeComponent();
        }

        public ConfirmDepositPage(int am,int re):this()
        {
            amount.Text ="\\"+ am.ToString();
            rest.Text = "\\"+re.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
