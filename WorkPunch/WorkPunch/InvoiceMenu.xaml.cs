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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

//Worked on: Patrick, Jan
namespace WorkPunch
{

    public partial class InvoiceMenu : Window
    {
        List<Chargeable> chargeables;
        Employee employee;
        List<Chargeable> invoiceChargeables;
        Job job;
        Work_Week workWeek;

        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        public InvoiceMenu(Work_Week workWeek,Job job,Employee employee)
        {
            InitializeComponent();
            chargeables = new List<Chargeable>();
            invoiceChargeables = new List<Chargeable>();
            this.employee = employee;
            this.job = job;
            this.workWeek = workWeek;
            
        }

        private void AddChargeableButton_Click(object sender, RoutedEventArgs e)
        {
            if(chargeableComboBox.SelectedItem!=null)
            {
                string selected = chargeableComboBox.SelectedItem.ToString();
                foreach (Chargeable c in chargeables)
                {
                    if (c.name == selected)
                    {
                        invoiceChargeables.Add(c);
                        MessageBox.Show("You have have added " + c.name + " to your invoice");
                    }

                }
            }
           else
            {

                MessageBox.Show("Please select a chargeable to add");
            }
            
           
        }

        private void CreateComissionButton_Click(object sender, RoutedEventArgs e)
        {
            chargeableComboBox.ItemsSource = null;
            new CreateCommission(chargeables).ShowDialog();


            chargeableComboBox.ItemsSource = chargeables;
        }

        private void CreateProductButton_Click(object sender, RoutedEventArgs e)
        {
            chargeableComboBox.ItemsSource = null;
            new CreateProduct(chargeables).ShowDialog();



            chargeableComboBox.ItemsSource = chargeables;

        }

        private void CreateInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            //Paths used for file creation
            string templatePath,invoiceExcelPath,invoicePDFPath;
            string employeeName, companyName;

            employeeName = employee.name.Replace(" ", "_");
            companyName =job.companyName.Replace(" ", "_");
            //Column and row values
            int nameRow=4, nameColumn=1, dateRow=5, dateColumn=5, siteRow=7, siteColumn=6, hoursRow=12, overtimeRow=13, chargeableRow = 14,quantityColumn=1, descriptionColumn=2, priceColumn=5,totalPriceColumn=6;
            //Initialize date to today
            string today = DateTime.Now.ToString("M/d/yyyy");

            //Gets base directory
            string folderPath=Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()+ "\\Invoice";

            //Path for template file to be copied
            templatePath = folderPath + "\\Template\\Invoice_Template.xlsx";
            //Path for excel file to be made and edited
            invoiceExcelPath=folderPath+"\\"+ employeeName + "_"+ companyName + "_"+ today+".xlsx";
            //path for pdf file that will later be saved
            invoicePDFPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)+ "\\Documents" + "\\" + employee.name + "_" + job.companyName + "_" + today;
            if (File.Exists(invoiceExcelPath))
                File.Delete(invoiceExcelPath);
            File.Copy(templatePath, invoiceExcelPath);
            

            xlWorkBook = xlApp.Workbooks.Open(invoiceExcelPath);
            xlWorkSheet = xlWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorkSheet.UsedRange;
            //Sets name
            xlRange.Cells[nameRow, nameColumn].Value2 = employee.name;

            //Set Date
            xlRange.Cells[dateRow,dateColumn].Value2 = today;

            //Sets company name
            xlRange.Cells[siteRow, siteColumn].Value2 = job.companyName;

            //Set Hours Worked
            xlRange.Cells[hoursRow,quantityColumn].Value2 =workWeek.weeklyHours;
            xlRange.Cells[hoursRow,descriptionColumn].Value2 ="Hours Worked";
            xlRange.Cells[hoursRow, priceColumn].Value2 = job.hourlyRate;
            xlRange.Cells[hoursRow,totalPriceColumn].Value2 =workWeek.CalculateHoursPay();

            //Set Overtime Hours Worked
            xlRange.Cells[overtimeRow, quantityColumn].Value2 = workWeek.overtimeHours;
            xlRange.Cells[overtimeRow, descriptionColumn].Value2 = "Overtime Hours Worked";
            xlRange.Cells[overtimeRow, priceColumn].Value2 = job.hourlyRate*Job.OVERTIMEMULTIPLIER;
            xlRange.Cells[overtimeRow, totalPriceColumn].Value2 = workWeek.CalculateOvertime();

            //Inputs all chargeables into invoice
            for (int i = 0; i < invoiceChargeables.Count; i++)
            {
                int row = i + chargeableRow;
                xlRange.Cells[row, descriptionColumn].Value2 = chargeables[i].name;
                xlRange.Cells[row, priceColumn].Value2 = chargeables[i].price;
                if (chargeables[i] is Comission)
                {
                    Comission comission = (Comission)chargeables[i];
                    xlRange.Cells[row, quantityColumn].Value2 = string.Format(comission.commissionPercent.ToString()+"%");
                    xlRange.Cells[row, totalPriceColumn].Value2 = comission.CalculateTotalCost();
                }
                else if (chargeables[i] is Product)
                {
                    Product product = (Product)chargeables[i];
                    xlRange.Cells[row, quantityColumn].Value2 = product.quantity;
                    xlRange.Cells[row, totalPriceColumn].Value2 = product.CalculateTotalCost();
                }
            }
            xlWorkBook.Save();
            xlWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, invoicePDFPath);
            xlWorkBook.Close();
            xlApp.Quit();
            MessageBox.Show("Invoice saved to" + invoicePDFPath);
        }
    }
}
