namespace WildFarm.Models
{
    using System;
    using System.Collections.Generic;
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
            allowedFood = new List<string>
            {
                "Meat"
            };
            gainingWeight = 0.25;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
