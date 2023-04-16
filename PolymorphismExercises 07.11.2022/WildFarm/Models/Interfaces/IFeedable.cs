namespace WildFarm.Models.Interfaces
{
    public interface IFeedable
    {
        public int FoodEaten { get; }
        public void Eat(Food food);
    }
}
