using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;
using PrimeAnalyticsAddin.Global;
using System.Data;


using System.Reflection;


namespace PrimeAnalyticsAddin.WorkBookUtilities
{
    class ExcelUtilities
    {


        public void createNewWorkSheet()
        {

            //SessionData.currentWorkbook = (Excel.Workbook) Globals.ThisAddIn.Application.ActiveWorkbook;
            //SessionData.activeWorkSheet = SessionData.currentWorkbook.ActiveSheet;

            //Microsoft.Office.Interop.Excel.Application xlApp =  new Microsoft.Office.Interop.Excel.Application();
            //double[] myArray = { 0.25, 1.999, 20, 32,5,65,89 };
            //double answer = xlApp.WorksheetFunction.Sum(myArray);
            //MessageBox.Show(answer.ToString());






        }

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


            activeWorkSheet.Columns.ColumnWidth = 100;

        }

        public void WriteCellByCell(int rows, int columns, Microsoft.Office.Interop.Excel.Worksheet worksheet)
        {
            for (var row = 1; row <= rows; row++)
            {
                for (var column = 1; column <= columns; column++)
                {
                    var cell = (Range)worksheet.Cells[row, column];
                    cell.Value2 = "Test";
                }
            }
        }


        //public void WriteArray(int rows, int columns, Microsoft.Office.Interop.Excel.Worksheet worksheet)
        //{
        //    var data = new object[rows, columns];
        //    for (var row = 1; row <= rows; row++)
        //    {
        //        for (var column = 1; column <= columns; column++)
        //        {
        //            data[row - 1, column - 1] = "Test";
        //        }
        //    }

        //    var startCell = (Range)worksheet.Cells[1, 1];
        //    var endCell = (Range)worksheet.Cells[rows, columns];
        //    var writeRange = worksheet.Range[startCell, endCell];

        //    writeRange.Value2 = data;
        //}





    }
}
