using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ATMSystem
{
    public partial class ConfirmRegisterPage : InputPage
    {
        public ConfirmRegisterPage()
        {
            InitializeComponent();
        }

        public ConfirmRegisterPage(string str) : this()
        {
            Encoding sjis = Encoding.GetEncoding("Shift-JIS");
            List<string> lists = new List<string>();
            StreamReader sr = new StreamReader(str + "\\" + str + "log.csv", sjis);

            while (!sr.EndOfStream)
            {

                string line = sr.ReadLine();

                lists.Add(line);
            }

            string[] values = lists[0].Split(',');


            dataGridView1.ColumnCount = values.Length;

            for (var i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].HeaderText = values[i];
            }

            for (var i = 1; i < lists.Count; i++)
            {
                var val = lists[i].Split(',');
                dataGridView1.Rows.Add(val);
            }

            sr.Close();
        }

        protected override void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}