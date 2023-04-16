namespace Composite.Models
{
    using Contracts;
    internal class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly List<GiftBase> gifts;
        public CompositeGift(string name, int price)
            : base(name, price)
        {
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public override int CalculateTotalPrice()
        {
            int totalPrice = this.price;

            foreach (var gift in gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }
    }
}
