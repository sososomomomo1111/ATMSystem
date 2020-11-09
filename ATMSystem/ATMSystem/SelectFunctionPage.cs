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
    public partial class SelectFunctionPage : Form
    {

        public string functionName { set; get; }

        public SelectFunctionPage()
        {
            functionName = "canceled";

            InitializeComponent();

        }

        public void functionButton_Click(object sender, EventArgs e)
        {

            var button = (System.Windows.Forms.Button)sender;
            functionName = button.Name;
            this.Close();
        }

        public void SelectFunctionPage_Closing(object sender,CancelEventArgs e)
        {
            //functionName
        }

    }
}
