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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
           NewAgentRegistration newAgentRegistration = new NewAgentRegistration();
            newAgentRegistration.Show();
=======
            new SignInSignUp().Show();
>>>>>>> 7993f9ef0c266520e0929d45ae785994cb0d1d5b
        }
    }
}