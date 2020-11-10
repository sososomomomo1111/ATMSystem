using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem
{
    class OwnerFunction
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


        public OwnerFunction(string str)
        {


            //fcNum = 1;
            functionDic = new Dictionary<FC, FunctionPart>();
            //functionDic.Add(FC.requestUserID, requestUserID);
            //functionDic.Add(FC.requestUserPW, requestPW);
            //functionDic.Add(FC.requestPayeeID, requestPayeeID);
            //functionDic.Add(FC.requestAmount, requestAmount);
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
            fcNum++;


        }


        void selectOwnerFunction()
        {

        }
        void requestOwnerID()
        {
            // InputOwnerIDPage inputOwnerIDPage = new InputOwnerIDPage("オーナーID", "オーナーIDを入力してください");
            //Application.Run(inputIDPage);
        }





    }
}
