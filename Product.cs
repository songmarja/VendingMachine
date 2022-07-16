using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Product
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public Product(string category, string name, int price, string description)
        {
            this.Category = category;
            this.Name = name;
            this.Price = price;
            _index++;
            this.ID = _index;
            Description = description;
        }
        private static int _index = 0;

        public string Examine()
        {
            return $"Some more info: {this.Name} - {this.Description}  Price: {this.Price:C}";
        }

        public abstract string Use();
    }
}
