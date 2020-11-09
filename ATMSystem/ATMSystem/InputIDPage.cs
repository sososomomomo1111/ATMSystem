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
    public partial class InputIDPage : ATMSystem.InputPage
    {
        public int id { get; set; }
        // public int id;
        const int TEXTLENGTH = 7;
        //public bool charCorrect { get; set; }

        public InputIDPage(string str) : base(str)
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //var textBox = (System.Windows.Forms.TextBox)sender;
            //var judgeText = textBox.Text.ToString();
            //var digits = (judgeText.Length == 7);
            ////confirmButton.Enabled = digits;//7桁でボタンを押せるように
            //note.Text = (confirmButton.Enabled = digits) ? "" : "桁数が間違っています。";
        }


        protected override void confirmButton_Click(object sender, EventArgs e)
        {
            int idd = 0;
            judgeInputText(ref idd, TEXTLENGTH);
            id = idd;
            base.confirmButton_Click(sender, e);


        }
    }
}
