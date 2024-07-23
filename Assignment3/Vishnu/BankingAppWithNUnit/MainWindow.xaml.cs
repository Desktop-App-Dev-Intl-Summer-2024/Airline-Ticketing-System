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
        private double endingBalance;
        private int numberOfChecks;

        public MainWindow()
        {
            InitializeComponent();

            this.endingBalance = 0.0;
            this.numberOfChecks = 0;
        }

        private double getServiceCharges()
        {
            double serviceCharges = 10.0;

            if (this.numberOfChecks < 20)
            {
                serviceCharges += 0.1 * this.numberOfChecks;
            }
            else if (this.numberOfChecks < 40)
            {
                serviceCharges += 0.08 * this.numberOfChecks;
            }
            else if (this.numberOfChecks < 60)
            {
                serviceCharges += 0.06 * this.numberOfChecks;
            }
            else
            {
                serviceCharges += 0.04 * this.numberOfChecks;
            }

            if (this.endingBalance < 400)
            {
                serviceCharges += 15;
            }

            return serviceCharges;
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
            this.endingBalance = double.Parse(CurrentBalanceTB.Text);
            this.numberOfChecks = int.Parse(NumberOfChecksTB.Text);

            ServiceChargesTB.Text = this.getServiceCharges().ToString();
            EndingBalanceTB.Text = (this.endingBalance - this.getServiceCharges()).ToString();
        }
    }
}