using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATMSystem
{
    class Log
    {
        Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
        DateTime date = DateTime.Now;
        int ID;
        int rest = 200000;
        int ammount = 100000;
        string name = "岡本";
        string transitionType = "預入";
        



        public void addLog(int id)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            //ファイルのパス
            string filePath = id + "log.csv";

            //テキストファイルからすべて読み込む
            string[] ss = System.IO.File.ReadAllLines(filePath,sjisEnc);
            //Listに変換
            List<string> sss = new List<string>(ss);

            int listcount = sss.Count;
            if (listcount <= 31)
            {
                sss.RemoveAt(1);
            }


            //ファイルに上書き
            //File.WriteAllLines(filePath,sss,sjisEnc);

            
            

            switch (transitionType)
                {
                    case "預入":
                    sss.Add(date+","+transitionType+","+name+","+null+","+ammount+","+rest);

                        break;

                    case "引出":
                        break;

                    case "振込":
                        break;

                }
            File.WriteAllLines(filePath, sss, sjisEnc);
            /*
            // ファイルを書き込みモード（上書き）で開く
            StreamWriter file = new StreamWriter(@id +"log.csv", false, Encoding.UTF8);
            // ファイルに書き込む
            file.WriteLine(date + transitionType + name + ammount+rest+"\n");
            // ファイルを閉じる
            file.Close();
            */
        }
        }

    }
