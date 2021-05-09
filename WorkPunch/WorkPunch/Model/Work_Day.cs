using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    public enum Day
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    class Work_Day
    {

        private int id;
        private double hoursWorked;
        private double breakTime = 30;
        private double lunchTime = 30;
        private Day day;
        



        public Work_Day()
        {

        }

        public void setHoursWorked(double hoursWorked)
        {
            this.hoursWorked = hoursWorked;
        }

    }
}
