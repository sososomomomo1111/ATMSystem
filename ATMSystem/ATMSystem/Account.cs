using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATMSystem
{
    class Account
    {
        public int id { get; set; } = -1;
        int pw;
        string name;
        int rest;
        public Account(int idd)
        {
            try
            {
                StreamReader sr = new StreamReader(@"test.csv");

            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }


    }
}
