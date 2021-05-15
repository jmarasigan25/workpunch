using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    public class Job
    {
        public string jobTitle { get; set; }
        public string companyName { get; set; }
        public double hourlyRate { get; set; }
        public double paidBreak { get; set; }
        public static double OVERTIMEMULTIPLIER = 1.5;
        public Job()
        {

        }
        public Job(double paidBreak,double hourlyRate)
        {
            this.paidBreak = paidBreak;
            this.hourlyRate = hourlyRate;
            
        }
        public Job(string jobTitle, string companyName,double paidBreak, double hourlyRate)
        {
            this.jobTitle = jobTitle;
            this.companyName = companyName;
            this.paidBreak = paidBreak;
            this.hourlyRate = hourlyRate;

        }
        public void setJobTitle(string jobTitle)
        {
            this.jobTitle = jobTitle;
        }

        public string getCompanyName()
        {
            return companyName;
        }

        public void setCompanyName(string companyName)
        {
            this.companyName = companyName;
        }

        public void setHourlyRate(double hourlyRate)
        {
            this.hourlyRate = hourlyRate;
        }

        public void setPaidBreak(double paidBreak)
        {
            this.paidBreak = paidBreak;
        }

    }
}
