using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length>15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public int ToppingCount
        {
            get { return toppings.Count; }
        }

        public double Calories
        {
            get
            {
                return dough.Calories + toppings.Sum(t => t.Calories);
            }
        }

        public void AddTopping(Topping topping)
        {
            if (ToppingCount==10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
    }
}
