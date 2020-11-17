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
        int ammount = -500000;
        string name = "岡本";
        string transitionType = "振込";
        public void addLog(int id)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            //ファイルのパス
            string filePath = id + "\\" + id + "log.csv";

            //テキストファイルからすべて読み込む
            string[] ss = System.IO.File.ReadAllLines(filePath, sjisEnc);
            //Listに変換
            List<string> sss = new List<string>(ss);

            //listの要素の数を取得
            int listcount = sss.Count;


            switch (transitionType)
            {
                case "預入":
                    sss.Add(date.ToString("yy/MM/dd") + "," + transitionType + "," + null + "," + null + "," + ammount + "," + rest);
                    break;

                case "引出":
                    sss.Add(date.ToString("yy/MM/dd") + "," + transitionType + "," + null + "," + ammount + "," + null + "," + (rest + 220));
                    sss.Add(date.ToString("yy/MM/dd") + "," + "手数料" + "," + null + "," + 220 + "," + null + "," + rest);
                    break;

                case "振込":
                    if (ammount < 0)
                    {
                        sss.Add(date.ToString("yy/MM/dd") + "," + transitionType + "," + name + "," + ammount + "," + null + "," + (rest + 220));
                        sss.Add(date.ToString("yy/MM/dd") + "," + "手数料" + "," + null + "," + 220 + "," + null + "," + rest);
                    }
                    else
                        sss.Add(date.ToString("yy/MM/dd") + "," + transitionType + "," + name + "," + null + "," + ammount + "," + rest);

                    break;

            }

            //先頭からログ情報が30件になるように削除
            if (listcount > 30)
            {
                int deli = listcount - 30;
                for (int i = 0; i <= deli; i++)
                {
                    sss.RemoveAt(1);
                }
            }

            //ファイルに書き込み
            File.WriteAllLines(filePath, sss, sjisEnc);

        }
    }
}
