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
    public partial class ConfirmRestPage : Form
    {


        public ConfirmRestPage()
        {
            InitializeComponent();
        }
        public ConfirmRestPage(int rest):this()
        {
           RestLabel.Text="\\"+rest.ToString();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
