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
using System.IO;



using System.Reflection;


namespace PrimeAnalyticsAddin.WorkBookUtilities
{
    class ExcelUtilities
    {
        public static int columnsCount = 0;
        public static int rowsCount = 0;

        public static Excel.Range xlRange = null;
        public static Excel.Workbook xlWorkBook = null;
        public static Excel.Worksheet xlWorksheet = null;

        public static Dictionary<string,string> columnNames = null;

        public void createNewWorkSheet()
        {

            //SessionData.currentWorkbook = (Excel.Workbook) Globals.ThisAddIn.Application.ActiveWorkbook;
            //SessionData.activeWorkSheet = SessionData.currentWorkbook.ActiveSheet;

            //Microsoft.Office.Interop.Excel.Application xlApp =  new Microsoft.Office.Interop.Excel.Application();
            //double[] myArray = { 0.25, 1.999, 20, 32,5,65,89 };
            //double answer = xlApp.WorksheetFunction.Sum(myArray);
            //MessageBox.Show(answer.ToString());


        }

        public void selectNewSheet ()
        {

        }


        //This method
        public void printDataTableToActiveSheet(System.Data.DataTable table, Microsoft.Office.Interop.Excel.Worksheet activeWorkSheet)
        {
            for (int i = 1; i < table.Columns.Count + 1; i++)
            {
                activeWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
            }

            for (int j = 0; j < table.Rows.Count; j++)
            {
                for (int k = 0; k < table.Columns.Count; k++)
                {
                    activeWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                }
            }
            activeWorkSheet.Columns.ColumnWidth = 20;
        }

        public static Dictionary<string, Excel.Worksheet> getSheetNames ()
        {

            Excel.Workbook activeWorkBook = (Excel.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
            

            Dictionary<string, Excel.Worksheet> dict = new Dictionary<string, Excel.Worksheet>();
            foreach (Excel.Worksheet worksheet in activeWorkBook.Worksheets)
            {
                dict.Add(worksheet.Name, worksheet);


                
            }


            
            return dict;
        }


        public static Dictionary<string, string> getColumnTitles(string sheetName)
        {

            Excel.Workbook activeWorkbook = (Excel.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
            Excel.Worksheet workSheet = (Excel.Worksheet)activeWorkbook.Sheets[sheetName];


            int x = 1;
            int y = 1;

            string value;


            Dictionary<string, string> dict = new Dictionary<string, string>();

            
            Excel.Range rng = (Excel.Range)workSheet.Cells[1, 1];

            value = (string)(rng.Cells[1, 1] as Excel.Range).Value2;
            //Excel.Range xlRange = activeWorkBook.ActiveSheet.UsedRange;


            while (value != null)
            {
              
                dict.Add(y.ToString(), value);

                y++;
                rng = (Excel.Range)workSheet.Cells[1, y];
                value = (string)(rng.Cells[1, 1] as Excel.Range).Value2;

                if (value == null)
                {
                    break;
                }
                                
            }

            columnNames = dict;

            return dict;

        }


        public static DataTable getData (string sheetName)
        {


            DataTable table = new DataTable();
            DataRow row;


            Excel.Workbook activeWorkbook = (Excel.Workbook)Globals.ThisAddIn.Application.ActiveWorkbook;
            Excel.Worksheet workSheet = (Excel.Worksheet)activeWorkbook.Sheets[sheetName];


            int x = 1;
            int y = 2;

            string  valueRows;     

            //Excel.Range xlRange = activeWorkBook.ActiveSheet.UsedRange;



            foreach (dynamic item in columnNames)
            {
                
                table.Columns.Add(item.Value);               

            }


            Excel.Range rng = (Excel.Range)workSheet.Cells[1, columnNames.Count];

            valueRows = (string)(rng.Cells[1, 1] as Excel.Range).Value2;

            while (valueRows != null)
            {
               
                row = table.NewRow();
                foreach (dynamic item in columnNames)
                {
                    valueRows = (string)(rng.Cells[1, x] as Excel.Range).Value2;
                    row[item.Value] = valueRows;
                    x++;              

                }


                table.Rows.Add(row);
                x = 1;
                y++;

                rng = (Excel.Range)workSheet.Cells[y, columnNames.Count];
                valueRows = (string)(rng.Cells[1, 1] as Excel.Range).Value2;
            }
            
            return table;

        }       


    }
}
