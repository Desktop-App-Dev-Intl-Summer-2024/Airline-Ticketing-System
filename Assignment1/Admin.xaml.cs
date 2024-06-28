using System;
using System.Collections.Generic;
using System.Data;
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

namespace Assignment1_FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private ApiRequest apiRequest;

        public Admin()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();
            PopulateDisplayGrid();
        }

        private void ProductIdTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ProductIdTbx.Text = "";
        }

        private void ProductNameTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ProductNameTbx.Text = "";
        }

        private void ProductAmountTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ProductAmountTbx.Text = "";
        }

        private void ProductPriceTbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ProductPriceTbx.Text = "";
        }

        private void AddProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = ProductNameTbx.Text;
                int id = int.Parse(ProductIdTbx.Text);
                double amount = double.Parse(ProductAmountTbx.Text);
                double price = double.Parse(ProductPriceTbx.Text);

                Product product = new Product(name, id, amount, price);

                // post to DB
                int status = apiRequest.postProductApi(product);
                // if success clear the input fields, success message
                // refresh/reload DisplayGrid
                if (status == 1)
                {
                    ClearInputs();
                    PopulateDisplayGrid();
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }

        private void FindProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = ProductNameTbx.Text.Trim();
                int id = ProductIdTbx.Text.Trim() != String.Empty ? int.Parse(ProductIdTbx.Text) : -1;

                Product foundPerson = apiRequest.getProductApi(id, name);

                if (foundPerson != null)
                {
                    ProductIdTbx.Text = foundPerson.getId().ToString();
                    ProductNameTbx.Text = foundPerson.getName();
                    ProductAmountTbx.Text = foundPerson.getAmount().ToString();
                    ProductPriceTbx.Text = foundPerson.getPrice().ToString();
                }
                else {
                    MessageBox.Show("Couldn't find any elements");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = ProductNameTbx.Text;
                int id = int.Parse(ProductIdTbx.Text);
                double amount = double.Parse(ProductAmountTbx.Text);
                double price = double.Parse(ProductPriceTbx.Text);

                Product product = new Product(name, id, amount, price);

                int status = apiRequest.putProductApi(product);

                if (status == 1)
                {
                    PopulateDisplayGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(ProductIdTbx.Text);

                int status = apiRequest.deleteProductApi(id);

                if (status == 1)
                {
                    ClearInputs();
                    PopulateDisplayGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateDisplayGrid() {
            DisplayProductsGrd.ItemsSource = apiRequest.getAllProducts().AsDataView();
        }

        private void ClearInputs() { 
            ProductIdTbx.Text = string.Empty;
            ProductNameTbx.Text = string.Empty;
            ProductAmountTbx.Text = string.Empty;
            ProductPriceTbx.Text = string.Empty;
        }
    }
}
