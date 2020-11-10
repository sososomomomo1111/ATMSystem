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
        //ユーザー機能
        cancel,
        requestUserID,
        requestUserPW,
        requestAmount,
        requestPayeeID,


        //オーナー機能
        selectOwnerFunction,
        requestOwnerID,

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
            functionDic = new Dictionary<FC, FunctionPart>
            {
                { FC.requestUserID, requestUserID },
                { FC.requestUserPW, requestPW },
                { FC.requestPayeeID, requestPayeeID },
                { FC.requestAmount, requestAmount }
            };
            // functionDic.Add(FC.confirmID, confirmID);



            functionName = str;
            switch (str)
            {

                case "deposit":
                    functionList.Add(FC.requestAmount);

                    break;
                case "withdraw":
                    functionList.Add(FC.requestUserPW);
                    functionList.Add(FC.requestAmount);

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
            fcNum++;

        }
        bool isNextExist() { return functionList.Count != fcNum; } //falseで次が無い





        void requestUserID()//ユーザーID入力
        {
            ////ユーザーID
            InputIDPage inputIDPage = new InputIDPage("ID", "IDを入力してください");
            Application.Run(inputIDPage);
            if (inputIDPage.charCorrect) id = inputIDPage.id;
            if (!(canceled = inputIDPage.isCanceled))
                confirmID(id);//ID確認もID要求の中で行う
        }

        void confirmID(int idd)//IDが存在しているか確認
        {
            Account account;
            try
            {
                account = new Account(idd);
                userAccount = account;
            }
            catch (Exception exception)
            {
                if (exception is FileNotFoundException || exception is DirectoryNotFoundException)
                {
                    canceled = true;
                    fcNum = 0;
                    MessageBox.Show("IDが存在しません。機能選択画面に戻ります。");
                    //throw;
                }
            }
        }



        void requestPayeeID()//振込先ID入力
        {

            InputIDPage inputIDPage = new InputIDPage("振込先ID", "振込先IDを入力してください");
            Application.Run(inputIDPage);
            if (inputIDPage.charCorrect) payeeId = inputIDPage.id;
            if (!(canceled = inputIDPage.isCanceled))
                confirmID(payeeId);//ID確認もID要求の中で行う
        }




        void requestPW()//PW入力
        {
            InputPWPage inputPWPage = new InputPWPage("パスワード", "パスワードを入力してください");
            Application.Run(inputPWPage);
            if (inputPWPage.charCorrect) pw = inputPWPage.pw;
            if (!(canceled = inputPWPage.isCanceled))
                checkPW(pw);//ID確認もID要求の中で行う
        }

        void checkPW(int PW)
        {
            if(userAccount.PW != pw)
            {
                canceled = true;
                fcNum = 0;
                MessageBox.Show("パスワードが一致しません。機能選択画面に戻ります。");
            }

        }


        void requestAmount()//取引金額入力
        {
            if (functionName == "deposit")
            {
               // InputDepositAmountPage inputDepositAmountPage = new InputDepositAmountPage();
            }
            else{
                InputAmountPage inputAmountPage = new InputAmountPage("取引金額", "取引金額を入力してください", functionName);
                Application.Run(inputAmountPage);
            }
        }

    }



}
