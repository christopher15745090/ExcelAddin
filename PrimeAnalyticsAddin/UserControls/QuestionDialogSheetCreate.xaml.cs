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
using PrimeAnalyticsAddin.Global;

namespace PrimeAnalyticsAddin.UserControls
{
    /// <summary>
    /// Interaction logic for QuestionDialogSheetCreate.xaml
    /// </summary>
    /// 

        
    public partial class QuestionDialogSheetCreate : Window
    {


        //The selection will be true when the radio button selected for New Workbook
        //and false for when the radio button selected is for the creation of a new workbook
        public static int option = 0;
        public QuestionDialogSheetCreate()
        {
            InitializeComponent();
        }

        //This function returns
        //     1 - If current sheet should be used
        //    -1 - if new workbook should be used
        public int getSelectedOption()
        {
            return option;
        }


        private void rbCurrent_Checked(object sender, RoutedEventArgs e)
        {

            //txtBoxPath.IsEnabled = false;            
            option = 1;
        }

        private void rbNew_Checked(object sender, RoutedEventArgs e)
        {

            //txtBoxPath.IsEnabled = true;
            option = -1;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
            FileUtilities fileUtil = new FileUtilities();

            txtBoxPath.Text = fileUtil.getSavePath("Excel File (*.xlsx)|*.xlsx");
        }
    }
}
