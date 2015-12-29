using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;

using System.Data;

namespace PrimeAnalyticsAddin.Global
{
    public static class SessionData
    {

        public static string username = "";
        public static string password = "";
        public static Boolean loggedIn = false;

        public static Excel.Workbook currentWorkbook = null;
        public static Excel.Worksheet activeWorkSheet = null;

        public static System.Data.DataTable dataTable = null;
    }


    

}
