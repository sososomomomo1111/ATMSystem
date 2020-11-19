using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATMSystem
{
    class Bill
    {
        public int amount { get; set; }
        public int count { get; set; }
        const int MAXCOUNT = 1000;

        public Bill()
        {
            count = MAXCOUNT / 2;
        }

        public Bill(string am)
        {
            Encoding sjis = Encoding.GetEncoding("Shift_JIS");

            StreamReader sr = null;
            IDictionary<string, int> keyValues = new Dictionary<string, int>();
            string[] values;

            bool canRead = true;

            try
            {
                sr = new StreamReader("bill.csv", sjis);
            }
            catch (Exception exception)
            {
                if (exception is FileNotFoundException || exception is DirectoryNotFoundException)
                    canRead = false;
                // throw;
            }

            if (canRead)
            {
                while (!sr.EndOfStream)
                {
                    // CSVファイルの一行を読み込む
                    string line = sr.ReadLine();
                    // 読み込んだ一行をカンマ毎に分けて配列に格納する
                    values = line.Split(',');
                    if (values.First<string>() == am)
                    {
                        amount = int.Parse(am);
                        count = int.Parse(values.Last<string>());
                    }
                }
                sr.Close();
            }
            
        }


        //金額から枚数計算して更新
        public void calculateCount(int num)
        {
            IDictionary<int, int> amountPairs = new Dictionary<int, int>();
            const int amount10k = 10000;
            const int amount5k = 5000;
            const int amount1k = 1000;
            amountPairs.Add(amount10k, num / amount10k);
            amountPairs.Add(amount5k, (num % amount10k) / amount5k);
            amountPairs.Add(amount1k, ((num % amount10k) % amount5k) / amount1k);
            updateBill(count += amountPairs[amount]);
        }

        //枚数で更新
        public void updateBill(int newCount)//更新してファイルに書き込み
        {
            Encoding sjis = Encoding.GetEncoding("Shift_JIS");
            StreamReader sr = null;
            StreamWriter sw = null;
            bool canRead = true;
            try
            {
                sr = new StreamReader("bill.csv", sjis);
            }
            catch (Exception exception)
            {
                if (exception is FileNotFoundException || exception is DirectoryNotFoundException)
                    canRead = false;
            }

            if (canRead)
            {
                List<string> readStringList = new List<string>();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    var vs = line.Split(',');
                    if (vs.First<string>() == amount.ToString())
                    {
                        readStringList.Add(amount.ToString() + "," + newCount.ToString());
                    }
                    else
                    {
                        readStringList.Add(line);
                    }
                }
                sr.Close();
                sw = new StreamWriter("bill.csv", false, sjis);
                foreach (var i in readStringList)
                {
                    sw.WriteLine(i);
                }
                sw.Close();
            }
        }

        public bool checkOver(int addCount)//オーバーしたらtrue
        {
            return count + addCount > MAXCOUNT;
        }

    }

}
