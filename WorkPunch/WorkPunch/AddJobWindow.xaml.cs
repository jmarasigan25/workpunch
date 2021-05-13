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
        List<Job> jobsList;
        public AddJobWindow(List<Job> jobsList)
        {
            InitializeComponent();

            this.jobsList = jobsList;
        }

        private void addJobButton_Click(object sender, RoutedEventArgs e)
        {
            Job job = new Job();

            job.setJobTitle(jobTitleTextBox.Text);
            job.setCompanyName(jobTitleTextBox.Text);

            double hourlyRate;
            double paidBreak;

            if (!double.TryParse(hourlyRateTextBox.Text, out hourlyRate))
            {
                MessageBox.Show("Input a valid hourly rate");
            }
            else
            {
                job.setHourlyRate(hourlyRate);
            }

            if (!double.TryParse(paidBreakTextBox.Text, out paidBreak))
            {
                MessageBox.Show("Input a valid paid break");
            }
            else
            {
                job.setPaidBreak(paidBreak);
            }

            jobsList.Add(job);
        }
    }
}
