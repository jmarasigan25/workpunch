using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    //Worked on: 
    public class Work_Week
    {
        private int id;
        private List<Work_Day> workDays;
        public double weeklyHours { get; set; }
        public double overtimeHours { get; set; }
        private Job job;
        public Work_Week(Job job,List<Work_Day> workDays)
        {
            this.job = job;
            this.workDays = workDays;
            SetHours();
        }
        public void SetHours()
        {
            double overtimeBarrier = 40;
            weeklyHours=0;
            foreach (Work_Day workDay in workDays)
            {
                weeklyHours += workDay.getPayedHours(job.paidBreak);
            }
            if(weeklyHours> overtimeBarrier)
            {
                overtimeHours = weeklyHours - overtimeBarrier;
                weeklyHours = weeklyHours - overtimeHours;
            }
                
        }
        public double CalculatePay()
        {
            double pay = 0;
            pay = job.hourlyRate * weeklyHours;
            pay += (job.hourlyRate * Job.OVERTIMEMULTIPLIER)*overtimeHours;
            return pay;
        }
        public double CalculateHoursPay()
        {
            double pay;
            pay = job.hourlyRate * weeklyHours;
            return pay;
        }
        public double CalculateOvertime()
        {
            double pay;
            pay = (job.hourlyRate * Job.OVERTIMEMULTIPLIER) * overtimeHours;
            return pay;
        }

    }
}
