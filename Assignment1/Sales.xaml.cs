using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections;
using System.Collections.Generic;
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
        ArrayList selectedProductList = new ArrayList();

        public Sales()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();
            PopulateSelectionComboBox();
            
        }

        //ADD SELECTED PRODUCT TO CART BUTTON CLICK
        private void addSelectedProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = productComboBox.SelectedItem.ToString();
                int id = int.Parse(productIDText.Text);
                double amount = double.Parse(qtyAvailableTxt.Text);
                double price = double.Parse(priceTxt.Text);
                int amountSelected = int.Parse(qtySelectedTxt.Text);
                GetSubtotal();

                SelectedProduct selectedProduct = new SelectedProduct(name, id, amount, price, amountSelected);

                Boolean foundInList = false;

                for (int i = 0; i >= selectedProductList.Count; i++)
                {
                    if (selectedProductList[i].getId.toString() == selectedProduct.getId)
                    {
                        System.Windows.MessageBox.Show("This item is already in your cart - please select Update instead!");
                        foundInList = true;
                        break;
                    }
                }

                if (foundInList = false)
                {
                    selectedProductList.Add(selectedProduct);
                    selectedProductGrid.ItemsSource = selectedProductList;
                    GetCartTotal(selectedProductList);
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
            selectedProductGrid.ItemsSource = null;
            ClearSelection();
            totalCartTxt.Text = "Total $ ";
        }

        //DELETE SELECTED PRODUCT BUTTON CLICK
        private void deleteSelectedProductBtn_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0;i >= selectedProductList.Count;i++)
            {
                if(selectedProductList[i].getId.toString() == productIDText.Text)
                {
                    selectedProductList.RemoveAt(i);
                }

                selectedProductGrid.ItemsSource = selectedProductList;
                GetCartTotal(selectedProductList);
                ClearSelection();
            }
        }

        //UPDATE CART BUTTON CLICK
        private void updateCartBtn_Click(object sender, RoutedEventArgs e)
        {
           Boolean foundInSelectedList = false;

            for (int i = 0; i >= selectedProductList.Count; i++)
            {
                if (selectedProductList[i].getId.toString() == productIDText.Text)
                {
                    selectedProductList[i].setAmountSelected(int.Parse(qtySelectedTxt.Text));
                    foundInSelectedList = true;
                    selectedProductGrid.ItemsSource = selectedProductList;
                    GetCartTotal(selectedProductList);
                    break;
                }

                if(foundInSelectedList = false)
                {
                    System.Windows.MessageBox.Show("This item is not currently in your cart - please select Add instead!");
                }
            }
        }

        //FIND PRODUCT BUTTON CLICK
        private void findProductBtn_Click(object sender, RoutedEventArgs e)
        {
            Boolean foundInSelectedList = false;
            Boolean foundInProductList = false;

            for (int i = 0; i >= selectedProductList.Count; i++)
            {
                if (selectedProductList[i].getId.toString() == productIDText.Text)
                {
                    productComboBox.SelectedItem = selectedProductList[i].getName;
                    productIDText.Text = selectedProductList[i].getId;
                    qtyAvailableTxt.Text = selectedProductList[i].getAmount;
                    qtySelectedTxt.Text = selectedProductList[i].getAmountSelected;
                    GetSubtotal();

                    foundInSelectedList = true;
                    break;
                }
                if (availableProduct[i].getId.toString() == productIDText.Text)
                {
                    productComboBox.SelectedItem = availableProduct[i].getName;
                    productIDText.Text = availableProduct[i].getId;
                    qtyAvailableTxt.Text = availableProduct[i].getAmount;
                    qtySelectedTxt.Text = "";

                    foundInProductList = true;
                    break;
                }
            }

            if(!foundInSelectedList && !foundInProductList)
            {
                System.Windows.MessageBox.Show("Item number not found. Try again.")
            }
        }

        //METHOD TO FILL COMBO BOX WITH AVAILABLE PRODUCT OBJECTS
        public void PopulateSelectionComboBox()
        {
            ArrayList availableProductArray = apiRequest.getAvailableProductsAPI();
            productComboBox.ItemsSource = availableProductArray;
        }

        //METHOD TO DISPLAY CURRENT CART TOTAL
        public void GetCartTotal(ArrayList selectedProductList)
        {
            double cartTotal = 0.0;

            for (int i = 0; i < selectedProductList.Count; i++)
            {
                cartTotal = cartTotal + selectedProductList[i].getAmountSelected() * selectedProductList[i].getPrice();

                totalCartTxt.Text = "Total $ " + cartTotal;
            }
        }

        //METHOD TO DISPLAY SELECTED PRODUCT SUBTOTAL
        public void GetSubtotal()
        {
            double amount = double.Parse(qtyAvailableTxt.Text);
            double price = double.Parse(priceTxt.Text);
            double subtotal = amount * price;
            subtotalTxt.Text = subtotal.ToString();
        }

        //METHOD TO CLEAR SELECTION
        public void ClearSelection()
        {
            productIDText.Text = "";
            priceTxt.Text = "";
            qtyAvailableTxt.Text = "";
            qtySelectedTxt.Text = "";
            subtotalTxt.Text = "";
        }
    }
}
