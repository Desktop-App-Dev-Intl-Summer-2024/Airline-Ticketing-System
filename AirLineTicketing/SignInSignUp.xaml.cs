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
    /// Interaction logic for SignInSignUp.xaml
    /// </summary>
    public partial class SignInSignUp : Window
    {
        public SignInSignUp()
        {
            InitializeComponent();
        }

        private void AgentSignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            new NewAgentRegistration().Show();
            this.Close();
        }

        private void UserSignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            new NewUserRegistration().Show();
            this.Close();
        }

        private void userSignInBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isLoggedIn = MainWindow.isloggedIn;

            if (isLoggedIn)
            {
                MessageBox.Show("User Already Logged in!");
            }
            else { 
                new UserSignIn().Show();
                this.Close();
            }
        }

        private void agentSignInBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isLoggedIn = MainWindow.isloggedIn;

            if (isLoggedIn)
            {
                MessageBox.Show("User Already Logged in!");
            }
            else
            {
                new AgentSignIn().Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
