using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ATMSystem
{

    class Atm
    {
        UserFunction userFunction;
        OwnerFunction ownerFunction;
        public bool isCanceled { get; }


        int functionNumber = 0;
        public IDictionary<string, int> functionDic;
      //  public bool isCanceled;

        public Atm()
        {
            SelectFunctionPage selectFunctionPage = new SelectFunctionPage();
            Application.Run(selectFunctionPage);


            var functionName = selectFunctionPage.functionName;//何が選択されたか
            selectFunctionPage = null;

            functionDic = new Dictionary<string, int>
            {
                { "deposit", 1 },
                { "withdraw",2 },
                { "fund",3 },
                { "confirmRest",4 },
                { "register",5 },
                { "confirmBillCount",6 },
                { "controlBillCount",7 },
                {"canceled",0 }

            };
            functionNumber = functionDic[functionName];

            if (functionNumber >= 1 && functionNumber <= 5)
                userFunction = new UserFunction(functionName);

            if (functionNumber >= 6)
                ownerFunction = new OwnerFunction(functionName);
            isCanceled = (functionNumber == 0);
                
                
        }

        public void excute()
        {
            if (functionNumber >= 1 && functionNumber <= 5)
                userFunction.execute();
            else if (functionNumber >= 6)
                ownerFunction.execute();
            
        }

    }
}
