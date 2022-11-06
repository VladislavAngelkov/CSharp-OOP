using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double DEFAULT_CALORIES_PER_GRAM = 2;
        private string flourType;
        private string backingTechnique;
        private int grams;
        public Dough(string flourType, string backingTechnique, int grams)
        {
            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique;
            this.Grams = grams;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public string BackingTechnique
        {
            get { return backingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                backingTechnique = value;
            }
        }
        public int Grams
        {
            get { return grams; }
            private set
            {
                if (value <1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }
        public double Calories
        {
            get { return CaloriesPerGram() * grams; }
        }
        private double CaloriesPerGram()
        {

            double modifier = 1;
            if (flourType.ToLower() == "white")
            {
                modifier *= 1.5;
            }

            if (backingTechnique.ToLower() == "crispy")
            {
                modifier *= 0.9;
            }
            else if (backingTechnique.ToLower() == "chewy")
            {
                modifier *= 1.1;
            }

            return DEFAULT_CALORIES_PER_GRAM * modifier;
        }

    }
}
