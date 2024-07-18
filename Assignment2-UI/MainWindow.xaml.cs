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

namespace Assignment1_FarmersMarketApp
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

        //CUSTOMER BUTTON: ENTER SALES MODULE
        private async void customerEnterBtn_Click(object sender, RoutedEventArgs e)
        {
            new Sales().Show();
        }

        //ADMIN BUTTON: ENTER ADMIN MODULE
        private void adminEnterBtn_Click(object sender, RoutedEventArgs e)
        {
            new Admin().Show();
        }
    }
}