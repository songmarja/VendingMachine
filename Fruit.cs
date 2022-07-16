using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Fruit : Product
    {
        public Fruit(string category, string name, int price, string description) : base(category, name, price, description)
        {

        }

        public override string Use()
        {
            return "Fruit feels good for body and soul! Just eat!";
        }
    }
}
