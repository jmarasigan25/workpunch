using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    //Worked on: 
    public enum Day
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    public class Work_Day
    {

        private int id;
        private double hoursWorked;
        private double breakTime;
        private double lunchTime;
        private Day day;
        public Work_Day(Day day,double hoursWorked,  double lunchTime, double breakTime)
        {
            this.day = day;
            this.hoursWorked = hoursWorked;
            this.breakTime = breakTime;
            this.lunchTime = lunchTime;
        }

        public void setHoursWorked(double hoursWorked)
        {
            this.hoursWorked = hoursWorked;
        }
        public double getPayedHours(double payedBreak)
        {
            payedBreak = breakTime-payedBreak;
            if (payedBreak < 0)
                payedBreak = 0;
            if (hoursWorked == 0)
                return 0;
            else
                return hoursWorked - lunchTime - payedBreak;
        }

    }
}
