using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();

            foreach (var person in personsInfo)
            {
                try
                {
                    string[] info = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = info[0];
                    decimal money = decimal.Parse(info[1]);
                    Person currPerson = new Person(name, money);
                    persons.Add(currPerson);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] productInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();

            foreach (var product in productInfo)
            {
                try
                {
                    string[] info = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = info[0];
                    decimal cost = decimal.Parse(info[1]);
                    Product currProduct = new Product(name, cost);
                    products.Add(currProduct);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                string personName = command[0];
                string productName = command[1];

                Product currentProduct = products.First(p => p.Name == productName);

                persons.First(p => p.Name == personName).BuyProduct(currentProduct);
                
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var person in persons)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought ");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                }
            }
        }
    }
}
