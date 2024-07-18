using Newtonsoft.Json.Serialization;
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

        //DEFAULT CONSTRUCTOR
        public SelectedProduct() : base()
        {
            amountSelected = 0;
        }

        //CONSTRUCTOR WITH PARAMETER
        public SelectedProduct(string name, int id, double amount, double price, double amountSelected) : base(name, id, amount, price)
        {
            this.amountSelected = amountSelected;
        }

        //GETTER
        public double getAmountSelected()
        {
            return amountSelected;
        }

        //SETTER
        public void setAmountSelected(double amountSelected)
        {
            this.amountSelected = amountSelected;
        }

        //RETURN SUBTOTAL
        public double getSubTotal()
        {
            double subTotal = 0.0;

            subTotal = amountSelected * getPrice();

            return Math.Round(subTotal * 100) / 100.0;
        }

        //RETURN CART TOTAL
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

        //RETURN REMAINING AMOUNT OF ITEM
        public double getRemaingAmount()
        {
            return Math.Round((getAmount() - amountSelected) * 10) / 10.0;
        }
    }
}
