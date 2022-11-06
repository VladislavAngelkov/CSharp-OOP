using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string pizzaName = string.Join(" ", Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1));

            try
            {
                string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string doughType = doughInfo[1];
                string doughTechnique = doughInfo[2];
                int doughGrams = int.Parse(doughInfo[3]);
                Dough dough = new Dough(doughType, doughTechnique, doughGrams);

                Pizza pizza = new Pizza(pizzaName, dough);

                string[] toppingInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                while (toppingInfo[0] != "END")
                {
                    string toppingType = toppingInfo[1];
                    int toppingGrams = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, toppingGrams);

                    pizza.AddTopping(topping);
                    
                    toppingInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }
    }
}
