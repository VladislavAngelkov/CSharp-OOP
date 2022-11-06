namespace BorderControl.Models.Interfaces
{
    public interface IBuyer:ICitizen
    {
        public int Food { get; }
        public void BuyFood();
    }
}
