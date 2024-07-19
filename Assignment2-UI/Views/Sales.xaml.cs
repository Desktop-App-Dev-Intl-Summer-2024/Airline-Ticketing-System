using Assignment1_FarmersMarketApp.API;
using Assignment1_FarmersMarketApp.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Assignment1_FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        private ApiRequest apiRequest;
        private RestApiRequest restApiRequest;

        ArrayList selectedProductList;
        ArrayList products;

        DataTable selectedProductsTable;

        //CONSTRUCTOR
        public Sales()
        {
            selectedProductList = new ArrayList();
            products = new ArrayList();

            InitializeComponent();
            apiRequest = new ApiRequest();
            restApiRequest = new RestApiRequest();
            InitializeGridView();
            PopulateSelectionComboBox();
        }

        //COMBOBOX SELECTION OF ITEM: DISPLAY OBJECT ELEMENTS
        private void productComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Boolean foundInSelectedList = false;

                if (selectedProductList != null)
                {
                    for (int i = 0; i < selectedProductList.Count; i++)
                    {
                        SelectedProduct seletedProduct = (selectedProductList[i] as SelectedProduct);

                        if (seletedProduct.getName() == (string)productComboBox.SelectedItem)
                        {
                            productIDText.Text = seletedProduct.getId().ToString();
                            priceTxt.Text = seletedProduct.getPrice().ToString();
                            qtyAvailableTxt.Text = seletedProduct.getAmount().ToString();
                            qtySelectedTxt.Text = seletedProduct.getAmountSelected().ToString();

                            GetSubtotal();
                            foundInSelectedList = true;
                            break;
                        }
                    }
                }

                if (foundInSelectedList == false)
                {
                    for (int i = 0; i < products.Count; i++)
                    {

                        Product product = products[i] as Product;

                        if (product.getName() == (string)productComboBox.SelectedItem)
                        {
                            productIDText.Text = product.getId().ToString();
                            priceTxt.Text = product.getPrice().ToString();
                            qtyAvailableTxt.Text = product.getAmount().ToString();
                            qtySelectedTxt.Text = "0.0";
                            GetSubtotal();
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        //ADD SELECTED PRODUCT TO CART BUTTON CLICK
        private void addSelectedProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = productComboBox.SelectedItem.ToString();
                string id = productIDText.Text;
                string amountSelected = qtySelectedTxt.Text;
                string subtotal = subtotalTxt.Text;

                double amount = double.Parse(qtyAvailableTxt.Text);
                double price = double.Parse(priceTxt.Text);

                Boolean foundInList = false;

                if (selectedProductList != null) {
                    for (int i = 0; i < selectedProductList.Count; i++)
                    {
                        if (int.Parse(id) == (selectedProductList[i] as SelectedProduct).getId())
                        {
                            System.Windows.MessageBox.Show("This item is already in your cart - please select Update instead!");
                            foundInList = true;
                            break;
                        }
                    }
                }

                if (foundInList == false)
                {
                    SelectedProduct selectedProduct = new SelectedProduct(name, int.Parse(id), amount, price, double.Parse(amountSelected));
                    selectedProductList.Add(selectedProduct);

                    RefreshGridView();
                    UpdateCartTotal();
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //CLEAR CART BUTTON CLICK
        private void clearCartBtn_Click(object sender, RoutedEventArgs e)
        {
            selectedProductList.Clear();
            selectedProductsTable.Clear();
            ClearSelection();
            UpdateCartTotal();
        }

        //DELETE SELECTED PRODUCT BUTTON CLICK
        private void deleteSelectedProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < selectedProductList.Count; i++)
                {
                    if ((selectedProductList[i] as SelectedProduct).getId() == int.Parse(productIDText.Text))
                    {
                        selectedProductList.RemoveAt(i);

                        ClearSelection();
                        RefreshGridView();
                        UpdateCartTotal();

                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //UPDATE CART BUTTON CLICK
        private void updateCartBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Boolean foundInSelectedList = false;

                for (int i = 0; i < selectedProductList.Count; i++)
                {
                    if ((selectedProductList[i] as SelectedProduct).getId() == int.Parse(productIDText.Text))
                    {
                        (selectedProductList[i] as SelectedProduct).setAmountSelected(double.Parse(qtySelectedTxt.Text));
                        foundInSelectedList = true;

                        RefreshGridView();
                        UpdateCartTotal();

                        break;
                    }
                }

                if (foundInSelectedList == false)
                {
                    System.Windows.MessageBox.Show("This item is not currently in your cart - please select Add instead!");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        
        //FIND PRODUCT BUTTON CLICK
        private void findProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Boolean foundInSelectedList = false;
                Boolean foundInProductList = false;

                for (int i = 0; i < selectedProductList.Count; i++)
                {
                    if ((selectedProductList[i] as SelectedProduct).getId() == int.Parse(productIDText.Text))
                    {
                        productComboBox.SelectedItem = (selectedProductList[i] as SelectedProduct).getName();
                        productIDText.Text = (selectedProductList[i] as SelectedProduct).getId().ToString();
                        qtyAvailableTxt.Text = (selectedProductList[i] as SelectedProduct).getAmount().ToString();
                        qtySelectedTxt.Text = (selectedProductList[i] as SelectedProduct).getAmountSelected().ToString();
                        priceTxt.Text = (selectedProductList[i] as SelectedProduct).getPrice().ToString();

                        GetSubtotal();

                        foundInSelectedList = true;
                        break;
                    }
                }

                if(foundInSelectedList == false)
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        if ((products[i] as Product).getId() == int.Parse(productIDText.Text))
                        {
                            productComboBox.SelectedItem = (products[i] as Product).getName();
                            productIDText.Text = (products[i] as Product).getId().ToString();
                            qtyAvailableTxt.Text = (products[i] as Product).getAmount().ToString();
                            qtySelectedTxt.Text = "0.0";
                            priceTxt.Text = (products[i] as Product).getPrice().ToString();

                            foundInProductList = true;
                            break;
                        }
                    }
                }

                if (!foundInSelectedList && !foundInProductList)
                {
                    System.Windows.MessageBox.Show("Item number not found. Try again.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        
        //CONFIRM FOR PURCHASE BUTTON CLICK - UPDATE DB
        private async void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int status = await restApiRequest.updateDbWithPurchase(selectedProductList);

                if (status > 0)
                {
                    PopulateSelectionComboBox();
                    ClearSelection();
                    selectedProductList.Clear();
                    UpdateCartTotal();
                    RefreshGridView();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //METHOD TO FILL COMBO BOX WITH AVAILABLE PRODUCT OBJECTS
        public async void PopulateSelectionComboBox()
        {
            try
            {
                List<Product> productList = await restApiRequest.getAllProducts();

                List<string> productNames = new List<string>();

                foreach (Product product in productList)
                {
                    products.Add(product);
                    productNames.Add(product.getName());
                }

                productComboBox.ItemsSource = productNames;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //METHOD TO DISPLAY CURRENT CART TOTAL
        public void UpdateCartTotal()
        {
            double cartTotal = 0.0;

            if (selectedProductList != null) {

                for (int i = 0; i < selectedProductList.Count; i++)
                {
                    cartTotal = cartTotal + (selectedProductList[i] as SelectedProduct).getSubTotal();
                }

            } 

            totalCartTxt.Text = (Math.Round(cartTotal * 100) / 100.0).ToString();

        }

        //METHOD TO DISPLAY SELECTED PRODUCT SUBTOTAL
        public void GetSubtotal()
        {
            try
            {
                if (qtySelectedTxt.Text != string.Empty)
                {
                    double amount = double.Parse(qtySelectedTxt.Text);
                    double price = double.Parse(priceTxt.Text);

                    double invAmount = double.Parse(qtyAvailableTxt.Text);

                    if (amount > invAmount)
                    {
                        throw new Exception("Please chose an amount within inventory!");
                    }

                    double subtotal = amount * price;
                    subtotalTxt.Text = (Math.Round(subtotal) * 100 / 100.0).ToString();
                }
            }
            catch(Exception ex) { 
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //METHOD TO CLEAR SELECTION
        public void ClearSelection()
        {
            productIDText.Text = "";
            priceTxt.Text = "";
            qtyAvailableTxt.Text = "";
            qtySelectedTxt.Text = "";
            subtotalTxt.Text = "";
            productComboBox.SelectedIndex = -1;
        }

        //UPDATE SUBTOTAL ON QTY UPDATE
        private void qtySelectedTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            GetSubtotal();
        }

        //UPDATE SUBTOTAL ON KEY RELEASE
        private void qtySelectedTxt_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            GetSubtotal();

        }

        //SET UP GRID VIEW
        private void InitializeGridView() {
            selectedProductsTable = new DataTable("table");

            DataColumn colItem1 = new DataColumn("Name",
                Type.GetType("System.String"));
            DataColumn colItem2 = new DataColumn("ID",
                Type.GetType("System.String"));
            DataColumn colItem3 = new DataColumn("Selected Amount",
                Type.GetType("System.String"));
            DataColumn colItem4 = new DataColumn("Sub Total",
                Type.GetType("System.String"));

            selectedProductsTable.Columns.Add(colItem1);
            selectedProductsTable.Columns.Add(colItem2);
            selectedProductsTable.Columns.Add(colItem3);
            selectedProductsTable.Columns.Add(colItem4);

            selectedProductGrid.ItemsSource = new DataView(selectedProductsTable);
        }

        //UPDATE GRID VIEW
        private void RefreshGridView() {
            selectedProductsTable.Clear();

            for(int i = 0; i < selectedProductList.Count; i++)
            {
                SelectedProduct product = selectedProductList[i] as SelectedProduct;

                DataRow newRow;

                newRow = selectedProductsTable.NewRow();
                newRow["Name"] = product.getName();
                newRow["ID"] = product.getId();
                newRow["Selected Amount"] = product.getAmountSelected();
                newRow["Sub Total"] = product.getSubTotal();

                selectedProductsTable.Rows.Add(newRow);
            }
        }
    }
}
