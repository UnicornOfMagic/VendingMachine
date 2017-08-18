namespace VendingMachine
{
    public enum ProductType { Cola, Chips, Candy };

    public class Product
    {
        ProductType type;
        decimal price;
        int stock;

        public Product(ProductType type, decimal price, int stock)
        {
            this.Type = type;
            this.Price = price;
            this.Stock = stock;
        }

        public override string ToString()
        {
            return Type.ToString();
        }

        public ProductType Type { get => type; set => type = value; }
        public decimal Price { get => price; set => price = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
