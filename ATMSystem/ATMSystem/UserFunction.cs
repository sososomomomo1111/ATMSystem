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




    }

    class UserFunction
    {
        public List<FC> functionList;//enumの配列
        delegate void FunctionPart();//関数の変数のようなもの
        IDictionary<FC, FunctionPart> functionDic;//map型


        string functionName;
        public bool canceled { get; set; } = false;
        public int id { get; set; }
        public int payeeId;
        public int amount { get; set; }
        int pw;
        Account userAccount, payeeAccount;
        Bill bill1k, bill5k, bill10k;

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

            //紙幣更新確認用
            //bill1k = new Bill("1000");
            //bill5k = new Bill("5000");
            //bill10k = new Bill("10000");
            //bill1k.calculateCount(15000);
            //bill5k.calculateCount(15000);
            //bill10k.calculateCount(15000);

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

        public bool isCanceled()//キャンセルされた場合何もせず機能選択画面に戻る
        {
            if (canceled)
            {
                functionList[0] = FC.cancel;
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
        }


        //以下部分機能

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
            if (userAccount.PW != pw)
            {
                canceled = true;
                MessageBox.Show("パスワードが一致しません。機能選択画面に戻ります。");
            }

        }


        void requestAmount()//取引金額入力
        {
            if (functionName == "deposit")
            {
                InputDepositAmountPage inputDepositAmountPage = new InputDepositAmountPage();
                Application.Run(inputDepositAmountPage);
            }
            else
            {
                InputAmountPage inputAmountPage = new InputAmountPage("取引金額", "取引金額を入力してください", functionName);
                Application.Run(inputAmountPage);
            }
        }

        void outputPayee()
        {

        }
        void outputTransaction()
        {

        }
        void outputRest()
        {

        }
        void outputLog()
        {
            //ConfirmRegisterPage confirmRegisterPage = new ConfirmRegisterPage(id);
        }

    }



}
