namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
            }
        }
        public string FavouriteFood
        {
            get { return favouriteFood; }
            private set
            {
                favouriteFood = value;
            }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {name} and my fovourite food is {favouriteFood}";
        }
    }
}
