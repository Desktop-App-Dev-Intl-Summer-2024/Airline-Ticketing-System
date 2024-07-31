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
    /// Interaction logic for NewUserRegistration.xaml
    /// </summary>
    public partial class NewUserRegistration : Window
    {
        public NewUserRegistration()
        {
            InitializeComponent();
        }

        private void userUsernameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            userUsernameTxt.Text = "";
        }

        private void userPasswordTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            userPasswordTxt.Text = "";
        }

        private void userFirstNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            userFirstNameTxt.Text = "";
        }

        private void userLastNameTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            userLastNameTxt.Text = "";
        }

        private void userEmailTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            userEmailTxt.Text = "";
        }

        private void submitUserRegBtn_Click(object sender, RoutedEventArgs e)
        {
            String username = userUsernameTxt.Text;
            String password = userPasswordTxt.Text;
            String firstname = userFirstNameTxt.Text;
            String lastname = userLastNameTxt.Text;
            String email = userEmailTxt.Text;
            String dob = userDobDt.Text;

            User newUser = new User(username, password, firstname, lastname, email, dob);
            
            ApiRequest request = new ApiRequest();

            request.postUserApi(newUser);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new FAQ().Show();
        }

        private void logInBtn_Click(object sender, RoutedEventArgs e)
        {
            new UserSignIn().Show();
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            new SignInSignUp().Show();
            this.Close();
            
        }
    }
}
