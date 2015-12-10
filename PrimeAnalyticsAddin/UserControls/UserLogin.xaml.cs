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


namespace PrimeAnalyticsAddin.UserControls
{
    /// <summary>
    /// Interaction logic for Temp.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public UserLogin()
        {
            InitializeComponent();
        }


        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

            string username = "", password = "";
            Boolean loginStatus = false;

            
            username = username_Textbox.Text;
            password = passwordBox.Password;

            LoginTools login = new LoginTools();


            loginStatus = login.login_Validation(username, password);

            if (loginStatus == true)
            {


                this.Close();
            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        


    }
}
