using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch.Model
{
    class Product : Chargeable
    {
        public string description { get; set; }
        public int quantity { get; set; }
        public Product(int id, string name, long price,string description, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.description = description;
            this.quantity = quantity;
        }
    }
}
