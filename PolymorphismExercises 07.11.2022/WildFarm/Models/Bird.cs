namespace WildFarm.Models
{
    using System;

    using Interfaces;

    public abstract class Bird : Animal, IHaveWings
    {
        private double wingSize;
        
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize
        {
            get { return wingSize; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wings cannot be negative number or zero!");
                }
                wingSize = value;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
