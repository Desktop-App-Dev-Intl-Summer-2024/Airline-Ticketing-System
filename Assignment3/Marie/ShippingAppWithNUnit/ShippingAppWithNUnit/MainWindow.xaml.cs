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

namespace ShippingAppWithNUnit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Freight freight;
        public MainWindow()
        {
            InitializeComponent();
            freight = new Freight();
        }

        private void weightTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            weightTxt.Text = "";
        }

        private void distanceTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            distanceTxt.Text = "";
        }

        private void resultsButton_Click(object sender, RoutedEventArgs e)
        {
            freight.weight = double.Parse(weightTxt.Text);
            freight.distance = double.Parse(distanceTxt.Text);

            double results = freight.totalShippingCharges(freight.weight, freight.distance);

            shippingResults.Text = "Shipping charges: $" + results;
        }
    }
}