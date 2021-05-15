using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    //Worked on: Patrick
    class Comission : Chargeable
    {
        public double commissionPercent { get; set; }
        public Comission(string name, double price, double commissionPercent)
        {
            this.name = name;
            this.price = price;
            this.commissionPercent = commissionPercent;
        }
        public override double CalculateTotalCost()
        {
            return price * (double)(commissionPercent / 100);
        }
    }
}
