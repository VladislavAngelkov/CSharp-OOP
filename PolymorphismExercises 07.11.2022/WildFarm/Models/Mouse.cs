namespace WildFarm.Models
{
    using System.Collections.Generic;
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            allowedFood = new List<string>
            {
                "Vegetable",
                "Fruit"
            };
            gainingWeight = 0.10;
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
