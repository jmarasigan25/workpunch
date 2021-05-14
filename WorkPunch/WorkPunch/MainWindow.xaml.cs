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

        double totalHours;
        double payedHours;
        double totalLunch;
        double totalBreak;
        public MainWindow()
        {
            InitializeComponent();

        }
        public void InitializeHours()
        {

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
            if (int.TryParse(e.Text, out hours)|| e.Text==".")
                e.Handled = false;
            else
                e.Handled = true;
            if (e.Text == "." && textBox.Text.Contains("."))
                e.Handled = true;
        }
        private void calculateHoursWorked()
        {
            totalHours = 0;
     

        }
        private void updatedHours(object sender, TextChangedEventArgs e)
        {
            var text = sender as TextBox;
            string temp = text.Text;

        }
    }
}
