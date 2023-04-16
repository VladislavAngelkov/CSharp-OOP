namespace WildFarm.Models
{
    using System;
    public static class FoodCreator
    {
        public static Food CreateFood(string[] foodInfo)
        {
            string type = foodInfo[0];
            int amount = int.Parse(foodInfo[1]);
            Food food;

            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(amount);
                    break;
                case "Fruit":
                    food = new Fruit(amount);
                    break;
                case "Meat":
                    food = new Meat(amount);
                    break;
                case "Seeds":
                    food = new Seeds(amount);
                    break;
                default:
                    throw new ArgumentException("Invalid food type!");
            }

            return food;
        }
    }
}
