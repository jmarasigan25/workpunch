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
using System.Text.RegularExpressions;

namespace WorkPunch
{

    //Worked on: Patrick
    public partial class CreateCommission : Window
    {
        List<Chargeable> chargeables;
        public CreateCommission(List<Chargeable> chargeables)
        {
            InitializeComponent();
            this.chargeables = chargeables;
        }

        private void IntValidationTextBox(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            int hours;
            double value;
            string afterDecimal;
            var textBox = sender as TextBox;
            //Allow numbers and decimals
            if (int.TryParse(e.Text, out hours) || e.Text == ".")
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
            if (text.Text == "" || text.Text == "." || text.Text == null)
            {
                text.Text = "0";
            }



        }

        private void saveCommissionButton_Click(object sender, RoutedEventArgs e)
        {
            if (comissionNameTextBox.Text == "" || comissionPriceTextBox.Text == "" || comissionPercentTextBox.Text == "")
                MessageBox.Show("Please fill out all the boxes");
            else
            {
                chargeables.Add(new Comission(comissionNameTextBox.Text, double.Parse(comissionPriceTextBox.Text),double.Parse(comissionPercentTextBox.Text)));
                MessageBox.Show("Comission Added");
                this.Close();
            }
        }
    }
}
