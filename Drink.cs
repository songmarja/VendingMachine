using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class Drink : Product
    {
        public Drink(string category, string name, int price, string description) : base(category, name, price, description)
        {

        }

        public override string Use()
        {
            return "Thirsty? Drink and enjoy!";
        }


    }
}
