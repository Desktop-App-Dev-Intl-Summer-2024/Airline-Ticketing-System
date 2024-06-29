using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_FarmersMarketApp
{
    internal class Product
    {
        private string name;
        private int id;
        private double amount;
        private double price;

        public Product() {
            this.name = "";
            this.id = 0;
            this.amount = 0.0;
            this.price = 0.0;
        }

        public Product(String name, int id, double amount, double price)
        {
            this.name = name;
            this.id = id;
            this.amount = amount;
            this.price = price;
        }

        public String getName() {
            return this.name;
        }

        public int getId()
        {
            return this.id;
        }

        public double getAmount() {
            return this.amount;
        }

        public double getPrice()
        {
            return this.price;
        }

        public void setName(String name)
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

        public void setPrice(double price) {
            this.price = price;
        }
    }
}
