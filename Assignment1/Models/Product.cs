using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_FarmersMarketApp.Models
{
    internal class Product
    {
        private string name;
        private int id;
        private double amount;
        private double price;

        public Product()
        {
            name = "";
            id = 0;
            amount = 0.0;
            price = 0.0;
        }

        public Product(string name, int id, double amount, double price)
        {
            this.name = name;
            this.id = id;
            this.amount = amount;
            this.price = price;
        }

        public string getName()
        {
            return name;
        }

        public int getId()
        {
            return id;
        }

        public double getAmount()
        {
            return amount;
        }

        public double getPrice()
        {
            return price;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setAmount(double amount)
        {
            this.amount = amount;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }
    }
}
