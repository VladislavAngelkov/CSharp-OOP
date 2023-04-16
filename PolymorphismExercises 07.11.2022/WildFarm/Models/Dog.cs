namespace WildFarm.Models
{
    using System.Collections.Generic;
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            allowedFood = new List<string>
            {
                "Meat"
            };
            gainingWeight = 0.40;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
