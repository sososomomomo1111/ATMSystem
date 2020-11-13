using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem
{
    public enum oFC
    {
        //オーナー機能
        cancel,
        selectOwnerFunction,
        requestOwnerID,
        confirmBillCount,
        controlBillCount,
    }

    class OwnerFunction
    {

        public List<oFC> functionList;
        delegate void FunctionPart();
        IDictionary<oFC, FunctionPart> functionDic;

        // const string ownerId = "112233445566";//12桁
        const long ownerId = 112233445566;//12桁


        string functionName;
        public bool canceled { get; set; } = false;
        public int id { get; set; }
        public int amount { get; set; }


        public OwnerFunction(string str)
        {


            functionDic = new Dictionary<oFC, FunctionPart>
            {
                { oFC.requestOwnerID, requestOwnerID },
                { oFC.selectOwnerFunction,selectOwnerFunction },
                { oFC.confirmBillCount, confirmBillCount },
                { oFC.controlBillCount, controlBillCount }
            };

            functionList = new List<oFC>();
        }

        public bool isCanceled()
        {
            if (canceled)
            {
                try
                {
                    functionList[0] = oFC.cancel;
                }
                catch (ArgumentOutOfRangeException)
                {
                    ;
                }
            }
            return canceled;
        }

        public void execute()
        {
            requestOwnerID();
            if (!isCanceled()) selectOwnerFunction();
            foreach (var i in functionList)
            {
                if (isCanceled()) break;
                functionDic[i]();
            }
        }

        void requestOwnerID()
        {
            InputOwnerIDPage inputOwnerIDPage = new InputOwnerIDPage("オーナーID", "オーナーIDを入力してください");
            Application.Run(inputOwnerIDPage);
            canceled = !(inputOwnerIDPage.charCorrect && inputOwnerIDPage.ownerId == ownerId);
        }

        void selectOwnerFunction()
        {
            //オーナー機能選択画面
            SelectOwnerFunctionPage selectOwnerFunctionPage = new SelectOwnerFunctionPage("何をしますか？");
            Application.Run(selectOwnerFunctionPage);
            functionName = selectOwnerFunctionPage.functionName;//何が選択されたか
            selectOwnerFunctionPage = null;

            switch (functionName)
            {

                case "confirmBillCount":
                    functionList.Add(oFC.confirmBillCount);

                    break;
                case "controlBillCount":
                    functionList.Add(oFC.controlBillCount);
                    break;

                default:
                    functionList = null;

                    break;
            }
        }

        void confirmBillCount()
        {
            ConfirmBillPage confirmBillPage = new ConfirmBillPage();
            Application.Run(confirmBillPage);
        }

        void controlBillCount()
        {

        }



    }
}
