namespace WildFarm.Models
{
    using System.Collections.Generic;
    public class Tiger : Felines
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            allowedFood = new List<string>
            {
                "Meat"
            };
            gainingWeight = 1;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
