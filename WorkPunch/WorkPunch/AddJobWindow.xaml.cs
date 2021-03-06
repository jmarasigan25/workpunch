using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorkPunch
{
    /// <summary>
    /// Interaction logic for AddJobWindow.xaml
    /// </summary>
    public partial class AddJobWindow : Window
    {
        MainWindow mainWindow;
        List<Job> jobsList;
        public AddJobWindow(MainWindow mainWindow,List<Job> jobsList)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.jobsList = jobsList;
        }

        private void addJobButton_Click(object sender, RoutedEventArgs e)
        {
            Job job = new Job();

            job.setJobTitle(jobTitleTextBox.Text);
            job.setCompanyName(companyTextBox.Text);

            double hourlyRate;
            double paidBreak;

            if (!double.TryParse(hourlyRateTextBox.Text, out hourlyRate) ||hourlyRate<=0)
            {
                paidBreak = -1;
                MessageBox.Show("Input a valid hourly rate");
            }
            else
            {
                job.setHourlyRate(hourlyRate);
            }

            if (!double.TryParse(paidBreakTextBox.Text, out paidBreak) || paidBreak<=0)
            {
                paidBreak = -1;
                MessageBox.Show("Input a valid paid break");
            }
            else
            {
                job.setPaidBreak(paidBreak);
            }


            if (!String.IsNullOrEmpty(jobTitleTextBox.Text) && !String.IsNullOrEmpty(companyTextBox.Text) && hourlyRate>0 && paidBreak>0)
            {
                MessageBox.Show("Job added succesfully");
                jobsList.Add(job);

                foreach (Job listJob in jobsList)
                {
                    mainWindow.jobComboBox.Items.Add(listJob.getCompanyName());
                }

                this.Close();
            }

        }
    }
}
