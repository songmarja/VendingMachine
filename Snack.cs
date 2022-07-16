using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Snack : Product
    {
        //public const string Message = "Can't stop eating this!";

        public Snack(string category, string name, int price, string description) : base(category, name, price, description )
        {

        }
        
        public override string Use()
        {
            return "When you need snack, you need it... Eat and don't regret!";
        }
    }
}
