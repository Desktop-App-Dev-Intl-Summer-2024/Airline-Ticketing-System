using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirLineTicketing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool isloggedIn = false;

        public MainWindow()
        {
            InitializeComponent();
            setLogButtonText();
        }

        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isloggedIn)
            {
                MessageBox.Show("Logout success!");
                isloggedIn = false;
                setLogButtonText();
            }
            else {
                new SignInSignUp().Show();
                this.Close();
            }
        }

        private void setLogButtonText() {
            if (isloggedIn)
            {
                logBtn.Content = "Log out";
            }
            else {
                logBtn.Content = "Sign In/Sign Up";
            }
        }
    }
}