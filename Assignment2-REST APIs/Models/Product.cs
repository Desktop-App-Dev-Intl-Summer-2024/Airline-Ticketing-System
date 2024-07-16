namespace Assignment2.Models
{
    public class Product
    {
        public string name { get; set; }
        public int id { get; set; }
        public double amount { get; set; }
        public double price { get; set; }

        public Product() {
            this.name = "";
            this.id = 0;
            this.amount = 0;
            this.price = 0;
        }

        public Product(string name, int id, double amount, double price)
        {
            this.name = name;
            this.id = id;
            this.amount = amount;
            this.price = price;
        }
    }
}
