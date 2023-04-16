namespace CommandPattern.Models
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void IncreasePrice(decimal amount)
        {
            Price += amount;
        }
        public void DecreasePrice(decimal amount)
        {
            if (amount<Price)
            {
                Price -= amount;
            }
        }
        public override string ToString()
        {
            return $"Current price for the {Name} product is {Price}$.";
        }
    }
}
