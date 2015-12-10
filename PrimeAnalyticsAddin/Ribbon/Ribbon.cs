using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using PrimeAnalyticsAddin.UserControls;
using PrimeAnalyticsAddin.Global;
using System.Windows.Forms;
using System.Windows;
using PrimeAnalyticsAddin.WorkBookUtilities;
using PrimeAnalyticsAddin;

namespace PrimeAnalyticsAddin
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void BtnUpload_Click(object sender, RibbonControlEventArgs e)
        {



            UserLogin loginWindow = new UserLogin();
            loginWindow.ShowDialog();


        }

        private void SelectProcess_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            
        }



        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            ExcelUtilities util = new ExcelUtilities();

            util.createNewWorkSheet();
        }

        private void btnLoadTable_Click(object sender, RibbonControlEventArgs e)
        {
            if (SessionData.loggedIn == true)
            {

                LoadTable loadTable = new LoadTable();

                loadTable.ShowDialog();
            }
            else
            {
                UserLogin loginWindow = new UserLogin();
                loginWindow.ShowDialog();

                if (SessionData.loggedIn == true)
                {

                    LoadTable loadTable = new LoadTable();

                    loadTable.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Task could not be complete your are not logged in.");
                }
            }


        }

        private void btAddNewTable_Click(object sender, RibbonControlEventArgs e)
        {
            PushToCloudNew createNewTable = new PushToCloudNew();

            createNewTable.ShowDialog();

        }
    }
}
