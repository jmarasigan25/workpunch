using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    public class Job
    {
        private string jobTitle;
        private string companyName;
        private double hourlyRate;
        private double paidBreak;

        public Job()
        {

        }

        public void setJobTitle(string jobTitle)
        {
            this.jobTitle = jobTitle;
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
