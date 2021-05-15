using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    //Worked on: Patrick
    class Product : Chargeable
    {
        public string description { get; set; }
        public int quantity { get; set; }
        public Product(string name, double price,string description, int quantity)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }
        public override double CalculateTotalCost()
        {
            return price * (double)(quantity);
        }
    }
}
