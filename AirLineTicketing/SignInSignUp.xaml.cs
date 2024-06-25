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
        }
    }
}
