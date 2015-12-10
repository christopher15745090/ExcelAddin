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

namespace PrimeAnalyticsAddin.DebugUtilities
{
    /// <summary>
    /// Interaction logic for QuickViewDataTable.xaml
    /// </summary>
    public partial class QuickViewDataTable : Window
    {
        public QuickViewDataTable()
        {
            InitializeComponent();
        }

        public  void viewDataTable (System.Data.DataTable table)
        {
            dataGrid.ItemsSource = table.DefaultView;
            

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].Width = 200;
                
            }

            this.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }
    }
}
