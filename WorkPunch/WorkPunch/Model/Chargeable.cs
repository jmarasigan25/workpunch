using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    abstract class Chargeable
    {
        public int id { get; set; }
        public string name { get; set; }
        public long price { get; set; }
        public virtual long CalculateTotalCost()
        {
            return price;
        }
    }
}
