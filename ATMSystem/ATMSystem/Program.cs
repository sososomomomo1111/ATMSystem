using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Atm atm;
            do
            {
                atm = null;
                atm = new Atm();
                atm.excute();
            } while (!atm.isCanceled);


           
            //Application.Run(new SelectFunctionPage());
        }
    }
}
