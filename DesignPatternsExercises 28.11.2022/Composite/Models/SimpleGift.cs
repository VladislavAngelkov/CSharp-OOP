namespace Composite.Models
{
    internal class SimpleGift : GiftBase
    {
        public SimpleGift(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            return this.price;
        }
    }
}
