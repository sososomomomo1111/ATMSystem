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

        outputPayee,
        outputTransaction,
        updateAccount,


    }


    class UserFunction
    {

        const int FEE = 220;
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
            bill1k = new Bill("1000");
            bill5k = new Bill("5000");
            bill10k = new Bill("10000");
            functionDic = new Dictionary<FC, FunctionPart>
            {
                { FC.requestUserID, requestUserID },
                { FC.requestUserPW, requestPW },
                { FC.requestPayeeID, requestPayeeID },
                { FC.requestAmount, requestAmount },
                {FC.outputPayee,outputPayee },
                {FC.outputTransaction,outputTransaction },
                {FC.updateAccount,updateAccount }

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
                    functionList.Add(FC.updateAccount);
                    functionList.Add(FC.outputTransaction);
  
                    break;
                case "withdraw":
                    functionList.Add(FC.requestUserPW);
                    functionList.Add(FC.requestAmount);
                    functionList.Add(FC.updateAccount);
                    functionList.Add(FC.outputTransaction);

                    break;
                case "fund":
                    functionList.Add(FC.requestUserPW);
                    functionList.Add(FC.requestPayeeID);
                    functionList.Add(FC.requestAmount);
                    functionList.Add(FC.outputPayee);
                    functionList.Add(FC.outputTransaction);
                    functionList.Add(FC.updateAccount);
                    break;
                case "confirmRest":
                    functionList.Add(FC.requestUserPW);
                    functionList.Add(FC.outputTransaction);
                    break;
                case "register":
                    functionList.Add(FC.requestUserPW);
                    functionList.Add(FC.outputTransaction);
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
                confirmID(id, ref userAccount);//ID確認もID要求の中で行う
        }

        void confirmID(int idd, ref Account ac)//IDが存在しているか確認
        {
            Account account;
            try
            {
                account = new Account(idd);
                ac = account;
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
            {
                isSameId(id, payeeId);
                confirmID(payeeId, ref payeeAccount);//ID確認もID要求の中で行う
            }
        }

        bool isSameId(int idd, int payeeIdd)
        {
            bool isSame;
            if (isSame = (idd == payeeIdd))
            {
                MessageBox.Show("IDが振込先IDと同じです。機能選択画面に戻ります。");
            }
            return canceled = isSame;
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
            if (functionName == "deposit")//預入
            {
                InputDepositAmountPage inputDepositAmountPage = new InputDepositAmountPage();
                Application.Run(inputDepositAmountPage);
                if (!(canceled = inputDepositAmountPage.isCanceled))
                {
                    var one = inputDepositAmountPage.onebills;
                    var five = inputDepositAmountPage.fivebills;
                    var ten = inputDepositAmountPage.tenbills;
                    amount = one * bill1k.amount + five * bill5k.amount + ten * bill10k.amount;//枚数から金額計算

                    if (bill1k.checkOver(one) || bill5k.checkOver(five) || bill10k.checkOver(ten))//どれか1つでもオーバーした場合
                    {
                        canceled = true;
                        MessageBox.Show("紙幣枚数が多すぎます。機能選択画面に戻ります。");
                    }

                }
            }
            else//引出、振込
            {
                InputAmountPage inputAmountPage = new InputAmountPage("取引金額", "取引金額を入力してください", functionName, FEE);
                Application.Run(inputAmountPage);
                if (!(canceled = !inputAmountPage.charCorrect))
                {
                    if (functionName == "withdraw" && (amount % 1000) != 0)
                    {
                        canceled = true;
                        MessageBox.Show("1000円単位で入力してください。機能選択画面に戻ります。");
                    }
                    amount = inputAmountPage.amount;
                    checkAmount();
                }

            }
        }

        void updateBill()
        {
            //紙幣更新
            bill1k.calculateCount((functionName=="withdraw")?-amount:amount);
            bill5k.calculateCount((functionName == "withdraw") ? -amount : amount);
            bill10k.calculateCount((functionName == "withdraw") ? -amount : amount);
        }

        void checkAmount()//引出、振込時のみ金額が足りるか確認
        {
            if (userAccount.rest < amount)
            {
                canceled = true;
                MessageBox.Show("口座の残高が足りません。機能選択画面に戻ります。");
            }
        }


        void outputPayee()
        {
            OutputPayeePage outputPayeePage = new OutputPayeePage(payeeAccount.ID, payeeAccount.name);
            Application.Run(outputPayeePage);
            canceled = outputPayeePage.isCanceled;
        }

        void outputTransaction()
        {
            switch (functionName)
            {
                case "deposit":
                    ConfirmDepositPage confirmDepositPage = new ConfirmDepositPage(amount, userAccount.rest);
                    Application.Run(confirmDepositPage);

                    break;
                case "withdraw":
                    ConfirmWithdrawPage confirmWithdrawPage = new ConfirmWithdrawPage(amount, userAccount.rest);
                    Application.Run(confirmWithdrawPage);
                    break;
                case "fund":
                    ConfirmFundPage confirmFundPage = new ConfirmFundPage(amount, userAccount.rest - amount - FEE);
                    Application.Run(confirmFundPage);
                    canceled = confirmFundPage.isCanceled;

                    break;
                case "confirmRest":
                    ConfirmRestPage confirmRestPage = new ConfirmRestPage(userAccount.rest);
                    Application.Run(confirmRestPage);
                    break;
                case "register":
                    ConfirmRegisterPage confirmRegisterPage = new ConfirmRegisterPage(id.ToString());
                    Application.Run(confirmRegisterPage);
                    break;

                default:
                    functionList = null;
                    break;
            }
        }
        void updateAccount()//口座、ログ情報、紙幣情報更新
        {
            Log log;
            switch (functionName)
            {
                case "deposit":
                    userAccount.rest += amount;
                    userAccount.updateRest();
                    log = new Log(userAccount.ID, userAccount.rest, amount, userAccount.name, functionName);
                    log.addLog(userAccount.ID);
                    updateBill();
                    break;
                case "withdraw":
                    userAccount.rest -= amount+FEE;
                    userAccount.updateRest();
                    log = new Log(userAccount.ID, userAccount.rest, -amount, userAccount.name, functionName);
                    log.addLog(userAccount.ID);
                    updateBill();
                    break;
                case "fund":
                    //口座ログ更新
                    userAccount.rest -= amount+FEE;
                    userAccount.updateRest();
                    log = new Log(userAccount.ID, userAccount.rest, -amount, payeeAccount.name, functionName);
                    log.addLog(userAccount.ID);
                    //振込先更新
                    payeeAccount.rest += amount;
                    payeeAccount.updateRest();
                    Log payeeLog = new Log(payeeAccount.ID, payeeAccount.rest, amount, userAccount.name, functionName);
                    payeeLog.addLog(payeeAccount.ID);
                    break;
                case "confirmRest":
                    break;
                case "register":
                    break;

                default:
                    functionList = null;
                    break;
            }
        }

    }
}
