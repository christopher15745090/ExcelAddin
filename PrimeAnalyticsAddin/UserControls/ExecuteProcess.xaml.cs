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
using System.Windows.Forms;

namespace PrimeAnalyticsAddin.UserControls
{
    /// <summary>
    /// Interaction logic for ExecuteProcess.xaml
    /// </summary>
    public partial class ExecuteProcess : Window
    {
        dynamic processList;
        dynamic headersList;
        dynamic results;

        public ExecuteProcess()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }



        private void cbProcesses_Initialized(object sender, EventArgs e)
        {


            DataRequests dataRequest = new DataRequests();

            String loginUrl = "http://admin.primeanalytics.io/session/start";
            String targetUrl = "http://admin.primeanalytics.io/get/DBTables";
            processList = dataRequest.getDataList(loginUrl, targetUrl);

            List<string> data = new List<string>();
            foreach (dynamic element in processList)
            {
                data.Add(element["text"]);
            }

            cbProcesses.ItemsSource = data;

        }

        private void btnDescription_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("This will show a short description of the process that is selected.");
        }
    }
}
