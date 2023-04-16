namespace WildFarm.Models
{
    using System;
    using Interfaces;

    public abstract class Felines : Mammal, IHaveBreed
    {
        private string breed;
        protected Felines(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return breed; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Breed cannot be null or whitespace!");
                }
                breed = value;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
