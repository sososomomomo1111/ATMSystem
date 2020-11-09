using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ATMSystem
{
    public enum FC//FunctionCommand
    {
        cancel,
        requestUserID,
        requestUserPW,
        requestAmount,
        requestPayeeID,

    }

    class UserFunction
    {
        public List<FC> functionList;
        public int fcNum;//functionNumber 
        delegate void FunctionPart();
        IDictionary<FC, FunctionPart> functionDic;


        string functionName;
        public bool canceled { get; set; } = false;
        public int id { get; set; }
        public int payeeId;
        public int amount { get; set; }
        int pw;
        Account userAccount, payeeAccount;


        public UserFunction(string str)
        {
            functionList = new List<FC>();
            functionList.Add(FC.requestUserID);//ユーザーIDは必須なので無条件で追加
            canceled = false;
            //fcNum = 1;
            functionDic = new Dictionary<FC, FunctionPart>();
            functionDic.Add(FC.requestUserID, requestUserID);
            functionDic.Add(FC.requestUserPW, requestPW);
            functionDic.Add(FC.requestPayeeID, requestPayeeID);
            functionDic.Add(FC.requestAmount, requestAmount);
            // functionDic.Add(FC.confirmID, confirmID);



            functionName = str;
            switch (str)
            {

                case "deposit":
                    //functionList.Add(FC.confirmID);
                    functionList.Add(FC.requestAmount);

                    break;
                case "withdraw":
                    functionList.Add(FC.requestUserPW);
                    break;
                case "fund":
                    functionList.Add(FC.requestUserPW);
                    functionList.Add(FC.requestPayeeID);
                    functionList.Add(FC.requestAmount);
                    break;
                case "confirmRest":
                    functionList.Add(FC.requestUserPW);
                    break;
                case "register":
                    functionList.Add(FC.requestUserPW);
                    break;

                default:
                    functionList = null;
                    break;
            }
        }

        public bool isCanceled()
        {
            if (canceled)
            {
                functionList[0] = FC.cancel;
                fcNum = 0;
            }
            return canceled;
        }

        public void execute()
        {
            foreach (var i in functionList)
            {
                if (isCanceled()) break;
                functionDic[i]();
            }
            //switch (functionList[fcNum])
            //{
            //    case FC.cancel:
            //        break;
            //    case FC.requestUserID:
            //        requestUserID();
            //        break;
            //    case FC.requestAmount:
            //        requestAmount();
            //        break;

            //    default:
            //        break;
            //}
            fcNum++;

            // GlobalVariables.judgeEnd();

        }
        bool isNextExist() { return functionList.Count != fcNum; } //falseで次が無い





        void requestUserID()//ユーザーID入力
        {
            ////ユーザーID
            InputIDPage inputIDPage = new InputIDPage("ID");
            Application.Run(inputIDPage);
            if (inputIDPage.charCorrect) id = inputIDPage.id;
            if (!(canceled = inputIDPage.isCanceled))
                confirmID();//ID確認もID要求の中で行う
        }

        void confirmID()
        {
            Account account;
            try
            {
                account = new Account(1234567);
                userAccount = account;
            }
            catch (FileNotFoundException)
            {
                canceled = true;
                fcNum = 0;
                MessageBox.Show("IDが存在しません。機能選択画面に戻ります。");

            }

        }



        void requestPayeeID()//振込先ID入力
        {

            InputIDPage inputIDPage = new InputIDPage("振込先ID");
            Application.Run(inputIDPage);
            if (inputIDPage.charCorrect) payeeId = inputIDPage.id;

        }




        void requestPW()//PW入力
        {
            InputPWPage inputPWPage = new InputPWPage("PW");
            Application.Run(inputPWPage);

        }

        void checkPW()
        {

        }


        void requestAmount()//取引金額入力
        {
            //InputAmountPage inputAmountPage = new InputAmountPage();
            //inputAmountPage.Owner = Application.Current.MainWindow;
            //inputAmountPage.Show();
        }

    }



}
