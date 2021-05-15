using System;
using System.Collections.Generic;
using System.IO;
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

    //Worked on: Patrick
    public partial class NewEmployee : Window
    {
        Employee employee;
        public NewEmployee(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void employeeSaveButton_Click(object sender, RoutedEventArgs e)
        {
            string path = "../../Employee.txt";
            if (employeeNameTextBox.Text == "")
                MessageBox.Show("Please enter a name");
            else
            {
                employee.name = employeeNameTextBox.Text;
                using (StreamWriter streamWriter = File.CreateText(path))
                {
                    streamWriter.WriteLine(employee.name);
                }
                this.Close();
            }
        }
    }
}
