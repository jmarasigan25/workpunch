using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, Double> dayHour = new Dictionary<string, double>();
        Dictionary<string, Double> dayBreak = new Dictionary<string, double>();
        Dictionary<string, Double> dayLunch = new Dictionary<string, double>();
        bool initialized = false;
        double totalHours;
        double payedHours;
        double totalLunch;
        double unpayedBreak;
        public MainWindow()
        {
            InitializeComponent();
            initialized = true;

        }
        public void InitializeHoursWorked()
        {
            dayHour.Add("mondayHoursWorkedTextBox", double.Parse(mondayHoursWorkedTextBox.Text));
            dayHour.Add("tuesdayHoursWorkedTextBox", double.Parse(tuesdayHoursWorkedTextBox.Text));
            dayHour.Add("wednesdayHoursWorkedTextBox", double.Parse(wednesdayHoursWorkedTextBox.Text));
            dayHour.Add("thursdayHoursWorkedTextBox", double.Parse(thursdayHoursWorkedTextBox.Text));
            dayHour.Add("fridayHoursWorkedTextBox", double.Parse(fridayHoursWorkedTextBox.Text));
            dayHour.Add("saturdayHoursWorkedTextBox", double.Parse(saturdayHoursWorkedTextBox.Text));
            dayHour.Add("sundayHoursWorkedTextBox", double.Parse(sundayHoursWorkedTextBox.Text));
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void invoiceButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void jobComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        private void CalculatePay()
        {
            int overtimeBarrier = 40;
            double overtimeMultiplier = 1.5;
            double overtimeHours;
            double pay,totalPay;
            pay = double.Parse(hourlyPayTextBlock.Text);
            payedHours = totalHours - unpayedBreak - totalLunch;
            if (payedHours > overtimeBarrier)
            {
                overtimeHours = payedHours - overtimeBarrier;
                totalPay = (payedHours-overtimeHours) * pay;
                totalPay += overtimeHours * (pay * overtimeMultiplier);
                overtimeTextBlock.Text = overtimeHours.ToString();
            }
            else
            {
                totalPay = pay * payedHours;
                overtimeTextBlock.Text = "0";
            }
            payedHoursTextBlock.Text = payedHours.ToString();
            totalPayTextBlock.Text = ("$" + totalPay.ToString());


        }
        private void CalculateHoursWorked()
        {
            totalHours = 0;
            foreach (var item in dayHour)
            {
                totalHours += item.Value;
            }
        }
        private void CalculateLunch()
        {
            totalLunch = 0;
            foreach (var item in dayLunch)
            {
                totalLunch += item.Value;
            }
        }
        private void CalculateUnpayedBreak()
        {   
            double payedBreak = double.Parse(payedBreakTextBlock.Text);
            unpayedBreak = 0;
            foreach (var item in dayBreak)
            {
                unpayedBreak += (item.Value-payedBreak);
            }
        }
        private void UpdatedDailyHours(object sender, TextChangedEventArgs e)
        {
          
            var text = sender as TextBox;
            if (text.Text != "" && text.Text != ".")
            {
                double hours = double.Parse(text.Text);
                dayHour[text.Name] = hours;
                CalculateHoursWorked();
                if (initialized)
                {
                    CalculatePay();
                    if (totalHours < 0)
                        payedHoursTextBlock.Text = "0";
                    else
                        payedHoursTextBlock.Text = payedHours.ToString();
                }
            }
            
            
            
        }
        private void UpdatedDailyLunch(object sender, TextChangedEventArgs e)
        {
            var text = sender as TextBox;
            if (text.Text != "" && text.Text != ".")
            {
                double hours = double.Parse(text.Text);
                dayLunch[text.Name] = hours;
                CalculateLunch();
                if (initialized)
                    CalculatePay();
            }
            
            
        }
        private void UpdatedDailyBreak(object sender, TextChangedEventArgs e)
        {
            var text = sender as TextBox;
            if (text.Text != "" && text.Text != ".")
            {
                
                double hours = double.Parse(text.Text);
                dayBreak[text.Name] = hours;
                CalculateUnpayedBreak();
                if (initialized)
                    CalculatePay();
            }
           
        }
    }
}
