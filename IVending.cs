using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal interface IVending
    {
        int Purchase(int totalAmount);
        void ShowAll();
        int InsertMoney(Money[] moneys, int totalAmount);
        int EndTransaction(int totalLeft);
    }
}
