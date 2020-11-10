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
        public int fcNum;//functionNumber 
        delegate void FunctionPart();
        IDictionary<oFC, FunctionPart> functionDic;


        string functionName;
        public bool canceled { get; set; } = false;
        public int id { get; set; }
        public int amount { get; set; }


        public OwnerFunction(string str)
        {
            //オーナー機能選択画面
            SelectOwnerFunctionPage selectOwnerFunctionPage = new SelectOwnerFunctionPage();
            Application.Run(selectOwnerFunctionPage);
            var functionName = selectOwnerFunctionPage.functionName;//何が選択されたか
            selectOwnerFunctionPage = null;




            //fcNum = 1;
            functionDic = new Dictionary<oFC, FunctionPart>
            {
                { oFC.requestOwnerID, requestOwnerID },
                { oFC.confirmBillCount, confirmBillCount },
                { oFC.controlBillCount, controlBillCount }
            };

            functionName = str;
            switch (str)
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

        public bool isCanceled()
        {
            if (canceled)
            {
                functionList[0] = oFC.cancel;
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
        void requestOwnerID()
        {
            // InputOwnerIDPage inputOwnerIDPage = new InputOwnerIDPage("オーナーID", "オーナーIDを入力してください");
            //Application.Run(inputIDPage);
        }

        void confirmBillCount()
        {

        }

        void controlBillCount()
        {

        }



    }
}
