using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Data;
using System.Collections.ObjectModel;
using PrimeAnalyticsAddin.WorkBookUtilities;
using PrimeAnalyticsAddin.Global;
using Excel = Microsoft.Office.Interop.Excel;

namespace PrimeAnalyticsAddin.UserControls
{
    /// <summary>
    /// Interaction logic for LoadTable.xaml
    /// </summary>
    public partial class LoadTable : Window
    {


        dynamic processList;
        dynamic headersList;
        dynamic results;

        System.Data.DataTable dataTable;

        public LoadTable()
        {
            InitializeComponent();
        }

        private void cboxProcess_Initialized(object sender, EventArgs e)
        {
            DataRequests dataRequest = new DataRequests();
            
            String loginUrl = "http://admin.primeanalytics.io/session/start";
            String targetUrl = "http://admin.primeanalytics.io/process/getProcesses";
            processList = dataRequest.getDataList(loginUrl, targetUrl);

            List<string> data = new List<string>();
            foreach (dynamic element in processList)
            {
                data.Add(element["text"]);
            }

            cboxProcess.ItemsSource = data;

        }




        //The next section is invoked when the close button on the top right corner of the window is pressed.

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }



        //This next section is envoked when the user select the import button on the ribbon
        private void btnGet_Click(object sender, RoutedEventArgs e)
        {

            if(cboxProcess.SelectedItem.ToString() != null)
            {
                dataTable = loadTable();
            }
            

        }


        public System.Data.DataTable loadTable ()
        {

            String selected = "";
            String id = "";

            DataRequests dataRequest = new DataRequests();
            selected = cboxProcess.SelectedValue.ToString();

            //Get id from list

            foreach (dynamic processItem in processList)
            {

                if (processItem["text"] == selected)
                {
                    id = processItem["id"];
                }

            }


            String loginUrl = "http://admin.primeanalytics.io/session/start";
            String targetUrl = "http://admin.primeanalytics.io/process/getHeaders/" + id;
            headersList = dataRequest.getDataList(loginUrl, targetUrl);

            DataTable table = new DataTable();
            int columnCount = 0;

            foreach (dynamic headerElement in headersList)
            {
                table.Columns.Add(headerElement["text"], typeof(String));

                columnCount++;

            }

            loginUrl = "http://admin.primeanalytics.io/session/start";
            targetUrl = "http://admin.primeanalytics.io/process/processResults/" + id;
            results = dataRequest.getDataList(loginUrl, targetUrl);

            DataRow row;

            foreach (dynamic resultItem in results)
            {
                row = table.NewRow();

                foreach (dynamic headerElement in headersList)
                {

                    row[headerElement["text"]] = resultItem[headerElement["text"]];
                }

                table.Rows.Add(row);
            }

            dataGrid.ItemsSource = table.DefaultView;
          

            for (int i = 0; i < columnCount; i++)
            {
                dataGrid.Columns[i].Width = 200;

            }
            return table;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            ExcelUtilities util = new ExcelUtilities();

            QuestionDialogSheetCreate qDialog = new QuestionDialogSheetCreate();

            qDialog.Show();

            if (qDialog.getSelectedOption()== true)
            {

            }


            //util.printDataTableToActiveSheet(dataTable, (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.ActiveSheet);


            util.insertDataTableToSheet(dataTable, "Imported.xlsx");

            this.Hide();      
            
        }
    }
}
