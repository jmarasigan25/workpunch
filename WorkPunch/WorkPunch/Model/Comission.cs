using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch.Model
{
    class Comission : Chargeable
    {
        public double commissionPercent { get; set; }
        public Comission(int id,string name, long price, double commissionPercent)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.commissionPercent = commissionPercent;
        }
        public override long CalculateTotalCost()
        {
            return price * (long)(commissionPercent / 100);
        }
    }
}
