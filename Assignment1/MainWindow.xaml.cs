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

        private void customerEnterBtn_Click(object sender, RoutedEventArgs e)
        {
            new Sales().Show();
            this.Close();
        }

        private void adminEnterBtn_Click(object sender, RoutedEventArgs e)
        {
            new Admin().Show();
            this.Close();
        }
    }
}