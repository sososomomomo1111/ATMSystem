using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    public partial class SelectOwnerFunctionPage : Form
    {
        public string functionName { get; set; }

        public bool isCanceled = true;


        public SelectOwnerFunctionPage()
        {
            InitializeComponent();
        }

        public SelectOwnerFunctionPage(string exp) : this()
        {
            explain.Text = exp;
        }


        protected void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void functionButton_Click(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            functionName = button.Name;
            this.Close();
        }

    }
}
