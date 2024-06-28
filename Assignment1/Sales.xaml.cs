using System;
using System.Collections;
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
        List<SelectedProduct> selectedProductList = new ArrayList();

        public Sales()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();
            PopulateSelectionComboBox();
            
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double cartTotal = 0.0;

                string name = productComboBox.SelectedItem.ToString();
                int id = int.Parse(productIDText.Text);
                double amount = double.Parse(qtySelectedTxt.Text);
                double price = double.Parse(priceTxt.Text);
                int amountSelected = int.Parse(qtySelectedTxt.Text);

                SelectedProduct selectedProduct = new SelectedProduct(name, id, amount, price, amountSelected);

                for(int i = 0; i >= selectedProductList.Count; i++)
                {
                    if (selectedProductList[i].getId == selectedProduct.getId)
                    {
                        System.Windows.MessageBox.Show("This item is already in your cart - please select Update instead!");
                    }
                }

                selectedProductList.Add(selectedProduct);

                selectedProductGrid.DataContext = selectedProductList;

                cartTotal = cartTotal + selectedProduct.getSubTotal(selectedProduct.getAmount, selectedProduct.getPrice);

                totalCartTxt.Text = "Total $ " + cartTotal;

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

        private void clearCartBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
