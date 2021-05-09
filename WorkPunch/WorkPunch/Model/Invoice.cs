using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch.Model
{
    class Invoice
    {
        public int id { get; set; }
        public Work_Week workWeek{ get; set; }
        public List<Chargeable> chargeables { get; set; }
        public Invoice(int id, Work_Week workWeek, List<Chargeable> chargeables)
        {
            this.id = id;
            this.workWeek = workWeek;
            this.chargeables = chargeables;
        }
    }
}
