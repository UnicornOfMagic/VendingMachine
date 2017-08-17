namespace VendingMachine
{
    public enum ProductType { Cola, Chips, Candy };

    public class Product
    {
        ProductType type;
        double price;
        int stock;

        public Product(ProductType type, double price, int stock)
        {
            this.Type = type;
            this.Price = price;
            this.Stock = stock;
        }

        public ProductType Type { get => type; set => type = value; }
        public double Price { get => price; set => price = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
