using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    //Worked on: Patrick
    public abstract class Chargeable
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public virtual double CalculateTotalCost()
        {
            return price;
        }
        public override string ToString()
        {
            return this.name;
        }
    }
}
