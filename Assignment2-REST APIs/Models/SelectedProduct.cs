using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Assignment2.Models
{
    public class SelectedProduct : Product
    {
        public double amountSelected { get; set; }

        //CONSTRUCTOR
        public SelectedProduct(string name, int id, double amount, double price, double amountSelected) : base(name, id, amount, price)
        {
            this.amountSelected = amountSelected;
        }

        //GETTER/SETTER
        public double getAmountSelected()
        {
            return amountSelected;
        }

        public void setAmountSelected(double amountSelected)
        {
            this.amountSelected = amountSelected;
        }

        //RETURN ITEM SUBTOTAL
        public double getSubTotal()
        {
            double subTotal = 0.0;

            subTotal = amountSelected * price;

            return Math.Round(subTotal * 100) / 100.0;
        }

        //RETURN CART TOTAL
        public double calculateTotalCart(List<SelectedProduct> products)
        {
            double totalCart = 0.0;

            for (int i = 0; i < products.Count; i++)
            {
                double qty = products[i].getAmountSelected();
                double price = products[i].price;
                totalCart += qty * price;
            }

            return totalCart;
        }

        //RETURN REMAINING AMOUNT OF ITEM
        public double getRemaingAmount()
        {
            return Math.Round((amount - amountSelected) * 10) / 10.0;
        }
    }
}
