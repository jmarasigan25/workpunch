using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPunch
{
    public class Employee
    {
        private int id;
        public string name { get; set; }
        private int age;
        private List<Job> jobs;
        private List<Work_Week> workWeeks;

        public Employee()
        {

        }
        public Employee(string name)
        {
            this.name = name;
        }
       
        public Employee(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            jobs = new List<Job>();
            workWeeks = new List<Work_Week>();
        }

        public List<Job> getJobs()
        {
            return jobs;
        }

        public List<Work_Week> getWorkWeeks()
        {
            return workWeeks;
        }
    }
}
