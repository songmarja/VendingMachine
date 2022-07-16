using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Money
    {
        public int Denomination { get; set; }
        public string Currency { get; set; }

        public Money(int denomination, string currency)
        {
            this.Denomination = denomination;
            this.Currency = currency;
        }
    }
}
