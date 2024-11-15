﻿using System;
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
using Assignment1_FarmersMarketApp.API;
using Assignment1_FarmersMarketApp.Models;

namespace Assignment1_FarmersMarketApp
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private ApiRequest apiRequest;
        private DataTable productsTable;

        public Admin()
        {
            InitializeComponent();
            apiRequest = new ApiRequest();
            InitializeGridView();
            RefreshGridView();
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

        private async void AddProductBtn_Click(object sender, RoutedEventArgs e)
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
                    RefreshGridView();
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }

        //FIND SINGLE PRODUCT BUTTON CLICK
        private async void FindProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = ProductNameTbx.Text.Trim();
                int id = ProductIdTbx.Text.Trim() != String.Empty ? int.Parse(ProductIdTbx.Text) : -1;

                Product foundProduct = apiRequest.getProductApi(id, name);

                if (foundProduct != null)
                {
                    ProductIdTbx.Text = foundProduct.getId().ToString();
                    ProductNameTbx.Text = foundProduct.getName();
                    ProductAmountTbx.Text = foundProduct.getAmount().ToString();
                    ProductPriceTbx.Text = foundProduct.getPrice().ToString();
                }
                else {
                    MessageBox.Show("Couldn't find any elements");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private async void UpdateProductBtn_Click(object sender, RoutedEventArgs e)
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
                    RefreshGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void DeleteProductBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(ProductIdTbx.Text);

                int status = apiRequest.deleteProductApi(id);

                if (status == 1)
                {
                    ClearInputs();
                    RefreshGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeGridView() {
            productsTable = new DataTable("table");

            DataColumn colItem1 = new DataColumn("Name",
                Type.GetType("System.String"));
            DataColumn colItem2 = new DataColumn("ID",
                Type.GetType("System.String"));
            DataColumn colItem3 = new DataColumn("Amount",
                Type.GetType("System.String"));
            DataColumn colItem4 = new DataColumn("Price",
                Type.GetType("System.String"));

            productsTable.Columns.Add(colItem1);
            productsTable.Columns.Add(colItem2);
            productsTable.Columns.Add(colItem3);
            productsTable.Columns.Add(colItem4);

            DisplayProductsGrd.ItemsSource = productsTable.AsDataView();
        }

        private async void RefreshGridView() {
            productsTable.Clear();

            List<Product> productList = apiRequest.getAvailableProductsAPI();

            foreach (Product product in productList)
            {
                DataRow newRow;

                newRow = productsTable.NewRow();
                newRow["Name"] = product.getName();
                newRow["ID"] = product.getId();
                newRow["Amount"] = product.getAmount();
                newRow["Price"] = product.getPrice();

                productsTable.Rows.Add(newRow);
            }
        }

        private void ClearInputs() { 
            ProductIdTbx.Text = string.Empty;
            ProductNameTbx.Text = string.Empty;
            ProductAmountTbx.Text = string.Empty;
            ProductPriceTbx.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
            RefreshGridView();
        }
    }
}
