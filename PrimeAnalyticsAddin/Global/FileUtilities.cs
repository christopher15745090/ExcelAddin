using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeAnalyticsAddin.Global
{
    class FileUtilities
    {


        public string getSavePath(string filter)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            string directoryPath = "";
            saveFileDialog1.Filter = filter;
            //saveFileDialog1.Filter = "Excel File (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(saveFileDialog1.CheckFileExists == true)
                {

                   // saveFileDialog1.
                    directoryPath = saveFileDialog1.FileName;
                }               

            }

            return directoryPath;
        }


        public string getBrowsedPath ()
        {
            string sSelectedFolder;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.Description = "Custom Description"; //not mandatory

            if (fbd.ShowDialog() == DialogResult.OK)
                sSelectedFolder = fbd.SelectedPath;
            else
                sSelectedFolder = string.Empty;

            return null;
        }

    }

}
