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
        public int ID { get; set; }
        public int PW { get; set; }
        public int rest { get; set; }
        public string name { get; set; }

        Log log;

        public Account(int id)
        {
            //文字化け
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            StreamReader sr = null;
            string[] values = null;

            //IDが存在するかの判定
            try
            {
                // 読み込みたいCSVファイルのパスを指定して開く
                sr = new StreamReader(id + "\\" + id + ".csv", sjisEnc);
            }
            catch (FileNotFoundException)
            {
                //if (exception is FileNotFoundException || exception is DirectoryNotFoundException)
                //    canRead = false;
                Console.WriteLine("ERROR");
                //throw;
            }


            // 末尾まで繰り返す
            while (!sr.EndOfStream)
            {
                // CSVファイルの一行を読み込む
                string line = sr.ReadLine();
                // 読み込んだ一行をカンマ毎に分けて配列に格納する
                values = line.Split(',');
            }

            //必要なデータの代入
            name = values[0];
            ID = int.Parse(values[1]);
            PW = int.Parse(values[2]);
            rest = int.Parse(values[3]);

           // System.Console.ReadKey();
            sr.Close();
        }

        public void updateRest()
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            //ファイルのパス
            string filePath = ID + "\\" + ID + ".csv";

            //テキストファイルからすべて読み込む
            string[] ss = System.IO.File.ReadAllLines(filePath, sjisEnc);
            //Listに変換
            List<string> sss = new List<string>(ss);

            sss.RemoveAt(1);

            sss.Add(name + "," + ID + "," + PW + "," + rest);

            File.WriteAllLines(filePath, sss, sjisEnc);

        }

        void createLog()
        {
            Log newLog = new Log();
            newLog.addLog(ID);
        }


    }
}
