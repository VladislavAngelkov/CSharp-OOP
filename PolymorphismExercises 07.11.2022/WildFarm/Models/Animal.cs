
namespace WildFarm.Models
{
    using System;
    using System.Collections.Generic;

    using Interfaces;

    public abstract class Animal : IFeedable, ISoundable
    {
        private string name;
        private double weight;
        private int foodEaten;
        protected List<string> allowedFood;
        protected double gainingWeight;

        protected Animal(string name, double weight)
        {
            this.name = name;
            this.weight = weight;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        public double Weight
        {
            get { return weight; }
            private set
            {
                if (weight <= 0)
                {
                    throw new ArgumentException("Weight cannot be negative number or zero!");
                }
                weight = value;
            }
        }

        public int FoodEaten
        {
            get { return foodEaten; }

        }

        public virtual void Eat(Food food)
        {
            if (!allowedFood.Contains(food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            foodEaten += food.Amount;
            weight += food.Amount * gainingWeight;
        }
        public abstract string ProduceSound();
    }
}
