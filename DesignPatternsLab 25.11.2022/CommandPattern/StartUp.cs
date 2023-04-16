using CommandPattern.Enums;
using CommandPattern.Models;
using CommandPattern.Utilities;
using CommandPattern.Utilities.Contracts;

Product product = new Product("Shoes", 150);
Console.WriteLine(product.ToString());

ICommand command = new ProductCommand(product, PriceActions.Decrease, 50);
ModifyPrice mp = new ModifyPrice();
mp.SetCommand(command);
mp.Invoke();

Console.WriteLine(product.ToString());