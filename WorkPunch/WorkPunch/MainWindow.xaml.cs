using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkPunch
{
    //Worked on: Patrick

    /*
     Notes
        We did not implement a database, so it resets evertime
            except for your login name, we save a local txt file for that atleast
     */
    public partial class MainWindow : Window
    {
        static string path = "../../Employee.txt";
        double totalHours;
        double payedHours;
        double totalLunch;
        double unpayedBreak;
        List<Job> jobsList;
        Work_Week workWeek;
        Job job;
        Employee employee;
        public MainWindow()
        {
            InitializeComponent();
            jobsList = new List<Job>();
            if (File.Exists(path))
            {
                employee = new Employee(File.ReadLines(path).First());
            }
            else
            {
                employee = new Employee();
                new NewEmployee(employee).ShowDialog();
            }
            

        }
    
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (hourlyPayTextBlock.Text != "")
            {
                try
                {
                    List<Work_Day> workDays = new List<Work_Day>();
                    workDays.Add(new Work_Day(Day.Monday, double.Parse(mondayHoursWorkedTextBox.Text), double.Parse(mondayLunchTextBox.Text), double.Parse(mondayBreakTextBox.Text)));
                    workDays.Add(new Work_Day(Day.Tuesday, double.Parse(tuesdayHoursWorkedTextBox.Text), double.Parse(tuesdayLunchTextBox.Text), double.Parse(tuesdayBreakTextBox.Text)));
                    workDays.Add(new Work_Day(Day.Wednesday, double.Parse(wednesdayHoursWorkedTextBox.Text), double.Parse(wednesdayLunchTextBox.Text), double.Parse(wednesdayBreakTextBox.Text)));
                    workDays.Add(new Work_Day(Day.Thursday, double.Parse(thursdayHoursWorkedTextBox.Text), double.Parse(thursdayLunchTextBox.Text), double.Parse(thursdayBreakTextBox.Text)));
                    workDays.Add(new Work_Day(Day.Friday, double.Parse(fridayHoursWorkedTextBox.Text), double.Parse(fridayLunchTextBox.Text), double.Parse(fridayBreakTextBox.Text)));
                    workDays.Add(new Work_Day(Day.Saturday, double.Parse(saturdayHoursWorkedTextBox.Text), double.Parse(saturdayLunchTextBox.Text), double.Parse(saturdayBreakTextBox.Text)));
                    workDays.Add(new Work_Day(Day.Sunday, double.Parse(sundayHoursWorkedTextBox.Text), double.Parse(sundayLunchTextBox.Text), double.Parse(sundayBreakTextBox.Text)));
                    workWeek = new Work_Week(new Job(double.Parse(payedBreakTextBlock.Text), double.Parse(hourlyPayTextBlock.Text)), workDays);
                    payedHoursTextBlock.Text = workWeek.weeklyHours.ToString();
                    overtimeTextBlock.Text = workWeek.overtimeHours.ToString();
                    totalPayTextBlock.Text = workWeek.CalculatePay().ToString();
                }
                catch (Exception)
                {

                    MessageBox.Show("Please fill out all the boxes");
                }
            }
            else
            {
                MessageBox.Show("Please select your job");
            }
        }

        private void invoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (workWeek != null && job!=null)
            {
                new InvoiceMenu(workWeek,job,employee).ShowDialog();
            }
            else
            {
                MessageBox.Show("Please save your hours and Select a Job");
            }
        }

        private void jobComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = jobComboBox.SelectedItem.ToString();

            foreach(Job j in jobsList)
            {
                if (j.getCompanyName() == selected)
                {
                    job = j;
                }
                hourlyPayTextBlock.Text = job.hourlyRate.ToString();
                payedBreakTextBlock.Text = job.paidBreak.ToString();
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            int hours;
            var textBox = sender as TextBox;
            //Allow numbers and decimals
            if (int.TryParse(e.Text, out hours)|| e.Text==".")
                e.Handled = false;
            else
                e.Handled = true;
            //Only allow 1 decemimal
            if (e.Text == "." && textBox.Text.Contains("."))
                e.Handled = true;
        }
       
       
        private void MinimumZero(object sender, TextChangedEventArgs e)
        {
          
            var text = sender as TextBox;
            if (text.Text == "" || text.Text == "."||text.Text==null)
            {
                text.Text = "0";
            }



        }


            public void addJobButton_Click(object sender, RoutedEventArgs e)
        {
            AddJobWindow addJobWindow = new AddJobWindow(this, jobsList);
            addJobWindow.Show();
 
        }


    }
}
