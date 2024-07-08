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
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        //ADD RECORD BUTTON CLICK
        private void addRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            new AdminAddRecord().Show();
            this.Close();
        }

        //EDIT RECORD BUTTON CLICK
        private void editRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            new AdminEditRecord().Show();
            this.Close();
        }
    }
}
