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
    public partial class InputPWPage : InputPage
    {

        public int pw { get; set; }

        const int TEXTLENGTH = 4;


        public InputPWPage(string str,string exp) : base(str,exp)
        {
            InitializeComponent();
        }

        protected override void confirmButton_Click(object sender, EventArgs e)
        {

            int pww = 0;
            judgeInputText(ref pww, TEXTLENGTH);
            pw = pww;
            base.confirmButton_Click(sender, e);

        }
    }
}
