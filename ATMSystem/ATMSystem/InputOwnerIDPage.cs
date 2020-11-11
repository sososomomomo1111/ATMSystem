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
    public partial class InputOwnerIDPage : InputPage
    {

        const int TEXTLENGTH = 4;
        public long ownerId { get; set; }

        public InputOwnerIDPage(string str, string exp) : base(str, exp)
        {
            InitializeComponent();
        }

        protected override void confirmButton_Click(object sender, EventArgs e)
        {
            long idd = 0;
            judgeInputText(ref idd, TEXTLENGTH);
            ownerId = idd;
            base.confirmButton_Click(sender, e);


        }
    }
}
