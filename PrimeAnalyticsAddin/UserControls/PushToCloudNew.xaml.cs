using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Data;
using System.Collections.ObjectModel;
using PrimeAnalyticsAddin.WorkBookUtilities;
using PrimeAnalyticsAddin.DebugUtilities;
using PrimeAnalyticsAddin.Global;
using Excel = Microsoft.Office.Interop.Excel;

namespace PrimeAnalyticsAddin.UserControls
{
    /// <summary>
    /// Interaction logic for PushToCloud.xaml
    /// </summary>
    public partial class PushToCloudNew : Window
    {

        private static List<string> data = null;
        private static List<string> dataIncluded = null;
        public PushToCloudNew()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }

        private void cbSheetName_Initialized(object sender, EventArgs e)
        {

            Excel.Workbook activeWorkBook = (Excel.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;

            data = new List<string>();
            dataIncluded = new List<string>();

            foreach (Excel.Worksheet worksheet in activeWorkBook.Worksheets)
            {
                data.Add(worksheet.Name.ToString());
            }           


            cbSheetName.ItemsSource = data;



        }

        private void cbSheetName_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            Dictionary<string, string> sheetColumns = ExcelUtilities.getColumnTitles(cbSheetName.SelectedItem.ToString());

            List<string> col = new List<string>();


            foreach (dynamic columns in sheetColumns)
            {

                col.Add(columns.Value);

            }

            data = col;

            listBoxLeft.ItemsSource = col;

            listBoxRight.ItemsSource = dataIncluded;


        }

        private void btnInclude_Click(object sender, RoutedEventArgs e)
        {

            int selectedIndex = listBoxLeft.SelectedIndex;
            

            if (selectedIndex != -1)
            {
                string selectedItem = listBoxLeft.SelectedItem.ToString();
                dataIncluded.Add(selectedItem);
                data.RemoveAt(selectedIndex);

                listBoxRight.Items.Refresh();
                listBoxLeft.Items.Refresh();
            }


        }

        private void btnExclude_Click(object sender, RoutedEventArgs e)
        {


            int selectedIndex = listBoxRight.SelectedIndex;
            

            if (selectedIndex != -1)
            {
                string selectedItem = listBoxRight.SelectedItem.ToString();


                data.Add(selectedItem);
                dataIncluded.RemoveAt(selectedIndex);

                listBoxRight.Items.Refresh();
                listBoxLeft.Items.Refresh();
            }

        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            Excel.Worksheet activeWorksheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.Sheets[cbSheetName.SelectedItem.ToString()];
            DataTable table = ExcelUtilities.getData(activeWorksheet.Name);

            QuickViewDataTable viewer = new QuickViewDataTable();
            viewer.viewDataTable(table);





        }
    }
    



}
