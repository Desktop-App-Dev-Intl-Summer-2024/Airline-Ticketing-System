using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        ArrayList selectedProductList;
        ArrayList products;
        DataTable selectedProductsTable;

        public Sales()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();
            PopulateSelectionComboBox();
            InitializeGridView();

            selectedProductList = new ArrayList();
            
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

                    DataRow NewRow = selectedProductsTable.NewRow();

                    NewRow["Name"] = name;
                    NewRow["ID"] = id;
                    NewRow["Selected Amount"] = amountSelected;
                    NewRow["Sub Total"] = subtotal;

                    selectedProductsTable.Rows.Add(NewRow);
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
            totalCartTxt.Text = "Total $ ";
        }

        //DELETE SELECTED PRODUCT BUTTON CLICK
        private void deleteSelectedProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i >= selectedProductList.Count; i++)
                {
                    if ((selectedProductList[i] as SelectedProduct).getId() == int.Parse(productIDText.Text))
                    {
                        selectedProductList.RemoveAt(i);
                    }

                    selectedProductGrid.ItemsSource = selectedProductList;
                    GetCartTotal(selectedProductList);
                    ClearSelection();
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

                for (int i = 0; i >= selectedProductList.Count; i++)
                {
                    if ((selectedProductList[i] as SelectedProduct).getId() == int.Parse(productIDText.Text))
                    {
                        (selectedProductList[i] as SelectedProduct).setAmountSelected(int.Parse(qtySelectedTxt.Text));
                        foundInSelectedList = true;
                        selectedProductGrid.ItemsSource = selectedProductList;
                        GetCartTotal(selectedProductList);
                        break;
                    }

                    if (foundInSelectedList = false)
                    {
                        System.Windows.MessageBox.Show("This item is not currently in your cart - please select Add instead!");
                    }
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
                ArrayList availableProductArray = apiRequest.getAvailableProductsAPI();
                Boolean foundInSelectedList = false;
                Boolean foundInProductList = false;

                for (int i = 0; i >= selectedProductList.Count; i++)
                {
                    if ((selectedProductList[i] as SelectedProduct).getId() == int.Parse(productIDText.Text))
                    {
                        productComboBox.SelectedItem = (selectedProductList[i] as SelectedProduct).getName;
                        productIDText.Text = (selectedProductList[i] as SelectedProduct).getId().ToString();
                        qtyAvailableTxt.Text = (selectedProductList[i] as SelectedProduct).getAmount().ToString();
                        qtySelectedTxt.Text = (selectedProductList[i] as SelectedProduct).getAmountSelected().ToString();
                        GetSubtotal();

                        foundInSelectedList = true;
                        break;
                    }
                    if ((availableProductArray[i] as Product).getId() == int.Parse(productIDText.Text))
                    {
                        productComboBox.SelectedItem = (availableProductArray[i] as Product).getName();
                        productIDText.Text = (availableProductArray[i] as Product).getId().ToString();
                        qtyAvailableTxt.Text = (availableProductArray[i] as Product).getAmount().ToString();
                        qtySelectedTxt.Text = "";

                        foundInProductList = true;
                        break;
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
        private void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int status = apiRequest.UpdateDatabaseWithPurchaseAPI(selectedProductList);

                if (status == 1)
                {
                    PopulateSelectionComboBox();
                    ClearSelection();

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //METHOD TO FILL COMBO BOX WITH AVAILABLE PRODUCT OBJECTS
        public void PopulateSelectionComboBox()
        {
            products = apiRequest.getAvailableProductsAPI();

            List<string> productNames = new List<string>();

            foreach (Product product in products)
            {
                productNames.Add(product.getName());
            }

            productComboBox.ItemsSource = productNames;
            
        }

        //METHOD TO DISPLAY CURRENT CART TOTAL
        public void GetCartTotal(ArrayList selectedProductList)
        {
            double cartTotal = 0.0;

            for (int i = 0; i < selectedProductList.Count; i++)
            {
                cartTotal = cartTotal + (selectedProductList[i] as SelectedProduct).getAmountSelected() * (selectedProductList[i] as SelectedProduct).getPrice();

                totalCartTxt.Text = "Total $ " + cartTotal;
            }
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
                    subtotalTxt.Text = subtotal.ToString();
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

        private void qtySelectedTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            GetSubtotal();
        }

        private void qtySelectedTxt_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            GetSubtotal();

        }

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
    }
}
