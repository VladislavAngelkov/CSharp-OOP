using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products
        {
            get { return products.AsReadOnly(); }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost>money)
            {
                Console.WriteLine($"{name} can't afford {product.Name}");
            }
            else
            {
                products.Add(product);
                money -= product.Cost;
                Console.WriteLine($"{name} bought {product.Name}");
            }
        }
    }
}
