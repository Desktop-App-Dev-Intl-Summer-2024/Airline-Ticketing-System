using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment1_FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        private ApiRequest apiRequest;

        public Sales()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();
            PopulateSelectionComboBox();
            List<SelectedProduct> selectedProductList = new List<SelectedProduct>();
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex) 
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public void PopulateSelectionComboBox()
        {
            System.Object[] availableProduct = new System.Object[5];

            for (int i = 0; i <= 9; i++)
            {
                availableProduct[i] = "Item" + i;
            }
            productComboBox.Items.AddRange(availableProduct);
        }
    }
}
