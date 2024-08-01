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
using System.Windows.Shapes;

namespace AirLineTicketing
{
    /// <summary>
    /// Interaction logic for UserSignIn.xaml
    /// </summary>
    public partial class UserSignIn : Window
    {
        ApiRequest apiRequest;
        public UserSignIn()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = usernameTxtBx.Text;
            string password = passwordTxtBx.Password;

            User? user = apiRequest.userSignInApi(userName, password);

            if (user != null)
            {
                MessageBox.Show("User log in success, redirecting to landing page!");
                MainWindow.isloggedIn = true;
                MainWindow.user = user;

                new MainWindow().Show();
                this.Close();
            }
            else { 
                MessageBox.Show("User log in failed, check username and password!");
            }
        }

        private void usernameTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            usernameTxtBx.Text = "";
        }

        private void passwordTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTxtBx.Password = "";
        }

        private void logInBtn_Click(object sender, RoutedEventArgs e)
        {
            new SignInSignUp().Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new FAQ().Show();
        }
    }
}
