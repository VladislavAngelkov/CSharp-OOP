namespace WildFarm.Models
{
    using System.Collections.Generic;
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            allowedFood = new List<string>
            {
                "Vegetable",
                "Fruit",
                "Meat",
                "Seeds"
            };
            gainingWeight = 0.35;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
