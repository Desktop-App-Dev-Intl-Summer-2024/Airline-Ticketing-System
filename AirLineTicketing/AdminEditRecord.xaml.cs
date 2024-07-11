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
    /// Interaction logic for AdminEditRecord.xaml
    /// </summary>
    public partial class AdminEditRecord : Window
    {
        public AdminEditRecord()
        {
            InitializeComponent();
        }

        //NAVIGATE TO ADD RECORD WINDOW
        private void addRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            new AdminAddRecord().Show();
            this.Close();
        }
    }
}
