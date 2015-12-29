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

            LoginTools tools = new LoginTools();



            
            username = username_Textbox.Text;
            password = passwordBox.Password;


            if (username != "" && password != "" && SessionData.loggedIn == false)
            {

                tools.login_Session(username, password);

                if (SessionData.loggedIn == true)
                {
                    this.Close();
                }

            }

            


        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        


    }
}
