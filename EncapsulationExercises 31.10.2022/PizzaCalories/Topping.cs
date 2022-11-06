using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double DEFAULT_CALORIES_PER_GRAM = 2;
        private string type;
        private int grams;

        public Topping(string type, int grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        public int Grams
        {
            get { return grams; }
            private set
            {
                if (value<1 || value>50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }
        public double Calories
        {
            get { return CaloriesPerGram() * grams; }
        }

        private double CaloriesPerGram()
        {
            double modifier = 1;

            if (type.ToLower() == "meat")
            {
                modifier *= 1.2;
            }
            else if (type.ToLower() == "veggies")
            {
                modifier *= 0.8;
            }
            else if (type.ToLower() == "cheese")
            {
                modifier *= 1.1;
            }
            else
            {
                modifier *= 0.9;
            }

            return DEFAULT_CALORIES_PER_GRAM * modifier;
        }
    }
}
