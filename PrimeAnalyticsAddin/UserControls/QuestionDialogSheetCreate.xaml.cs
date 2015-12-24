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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PrimeAnalyticsAddin.Global;
using PrimeAnalyticsAddin.WorkBookUtilities;

using Excel = Microsoft.Office.Interop.Excel;

namespace PrimeAnalyticsAddin.UserControls
{
    /// <summary>
    /// Interaction logic for QuestionDialogSheetCreate.xaml
    /// </summary>
    /// 

        
    public partial class QuestionDialogSheetCreate : Window
    {
         System.Data.DataTable table;

        //The selection will be true when the radio button selected for New Workbook
        //and false for when the radio button selected is for the creation of a new workbook
        public static int option = 0;
        public QuestionDialogSheetCreate()
        {
            InitializeComponent();
        }


        public QuestionDialogSheetCreate(System.Data.DataTable dataTable)
        {
            table = dataTable;
            InitializeComponent();
        }


        //This function returns
        //     1 - If current sheet should be used
        //    -1 - if new workbook should be used
        public int getSelectedOption()
        {
            return option;
        }




        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }





        private void btOK_Click(object sender, RoutedEventArgs e)
        {


            ExcelUtilities util = new ExcelUtilities();
            if (rbCurrent.IsChecked == true)
            {
                util.printDataTableToActiveSheet(table, (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);
            }
            else
            {
                util.insertDataTableToSheet(table, txtBoxPath.Text.ToString());

            }
            this.Hide();


        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {


            FileUtilities fileUtil = new FileUtilities();

            txtBoxPath.Text = fileUtil.getSavePath("Excel File (*.xlsx)|*.xlsx");


        }
    }
}
