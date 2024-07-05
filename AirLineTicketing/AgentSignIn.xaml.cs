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
    /// Interaction logic for AgentSignIn.xaml
    /// </summary>
    public partial class AgentSignIn : Window
    {
        ApiRequest apiRequest;
        public AgentSignIn()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();
        }

        //AGENT SIGN IN BUTTON 
        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = usernameTxtBx.Text;
            string password = passwordTxtBx.Text;
            string agentLicense = licenseTxtBx.Text;

            int status = apiRequest.agentSignInApi(userName, password, agentLicense);

            if (status == 1)
            {
                MessageBox.Show("Agent log in success, redirecting to landing page!");
                MainWindow.isloggedIn = true;

                new MainWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Agent log in failed, check username and password and verify license!");
            }
        }

        //CLEAR TEXT BOXES WHEN FOCUS
        private void usernameTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            usernameTxtBx.Text = "";
        }

        private void passwordTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTxtBx.Text = "";
        }

        private void licenseTxtBx_GotFocus(object sender, RoutedEventArgs e)
        {
            licenseTxtBx.Text = "";
        }

        //BACK BUTTON
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            new SignInSignUp().Show();
            this.Close();
        }
    }
}
