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

namespace BankingAppWithNUnit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Account account;

        public MainWindow()
        {
            InitializeComponent();
            account = new Account();
        }

        private void CurrentBalanceTB_GotFocus(object sender, RoutedEventArgs e)
        {
            CurrentBalanceTB.Text = "";
        }

        private void NumberOfChecksTB_GotFocus(object sender, RoutedEventArgs e)
        {
            NumberOfChecksTB.Text = "";
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            account.endingBalance = double.Parse(CurrentBalanceTB.Text);
            account.numberOfChecks = int.Parse(NumberOfChecksTB.Text);

            ServiceChargesTB.Text = account.getServiceCharges().ToString();
            EndingBalanceTB.Text = (account.endingBalance - account.getServiceCharges()).ToString();
        }
    }
}