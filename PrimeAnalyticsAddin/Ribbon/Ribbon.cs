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

        public Boolean status = false;

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

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
                    btnLogin.Label = "Logout";
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

        private void btnLogin_Click(object sender, RibbonControlEventArgs e)
        {


            if (SessionData.loggedIn == false)
            {
                UserLogin loginWindow = new UserLogin();
                loginWindow.ShowDialog();

                if (SessionData.loggedIn == true)
                {
                    btnLogin.Label = "Logout";

                }

                
            }
            else
            {
                LoginTools tools = new LoginTools();
                tools.logout_Session();


                if (SessionData.loggedIn == false)
                {
                    btnLogin.Label = "Login";

                }

            }



        }

        private void btnAppend_Click(object sender, RibbonControlEventArgs e)
        {

            if (SessionData.loggedIn == true)
            {

                Append append = new Append();
                append.ShowDialog();
            }
            else
            {
                UserLogin loginWindow = new UserLogin();
                loginWindow.ShowDialog();

                if (SessionData.loggedIn == true)
                {
                    btnLogin.Label = "Logout";
                    Append append = new Append();
                    append.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Task could not be complete your are not logged in.");
                }
            }

        }
    }
}
