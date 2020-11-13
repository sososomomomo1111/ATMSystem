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
    public partial class OutputPayeePage : Form
    {
        public bool isCanceled { set; get; } = false;

        public OutputPayeePage()
        {
            InitializeComponent();
        }

        internal OutputPayeePage(int amount,string payeeName) : this()
        {
            label4.Text = amount.ToString();
            label5.Text = payeeName;
        }

        private void OutputPayeePage_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            isCanceled = true;
        }
    }
}
