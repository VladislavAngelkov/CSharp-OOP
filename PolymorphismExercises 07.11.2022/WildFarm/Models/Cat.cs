namespace WildFarm.Models
{
    using System.Collections.Generic;
    public class Cat : Felines
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            allowedFood = new List<string>
            {
                "Meat",
                "Vegetable"
            };
            gainingWeight = 0.30;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
