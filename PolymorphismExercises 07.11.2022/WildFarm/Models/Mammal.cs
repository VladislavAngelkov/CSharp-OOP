namespace WildFarm.Models
{
    using System;

    using Interfaces;

    public abstract class Mammal : Animal, IHaveLivingRegion
    {
        private string livingRegion;
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return livingRegion; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Living region cannot be null or whitespace!");
                }
                livingRegion = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
