using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assignment1_FarmersMarketApp.Models
{
    internal class SelectedProduct : Product
    {
        private double amountSelected;

        public SelectedProduct(string name, int id, double amount, double price, double amountSelected) : base(name, id, amount, price)
        {
            this.amountSelected = amountSelected;
        }

        public double getAmountSelected()
        {
            return amountSelected;
        }

        public void setAmountSelected(double amountSelected)
        {
            this.amountSelected = amountSelected;
        }


        public double getSubTotal()
        {
            double subTotal = 0.0;

            subTotal = amountSelected * getPrice();

            return Math.Round(subTotal * 100) / 100.0;
        }

        public double calculateTotalCart(List<SelectedProduct> products)
        {
            double totalCart = 0.0;

            for (int i = 0; i >= products.Count; i++)
            {
                double qty = products[i].getAmountSelected();
                double price = products[i].getPrice();
                totalCart += qty * price;
            }

            return totalCart;
        }

        public double getRemaingAmount()
        {
            return Math.Round((getAmount() - amountSelected) * 10) / 10.0;
        }
    }
}
