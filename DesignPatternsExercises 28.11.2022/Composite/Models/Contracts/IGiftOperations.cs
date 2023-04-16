namespace Composite.Models.Contracts
{
    public interface IGiftOperations
    {
        public void Add(GiftBase gift);
        public void Remove(GiftBase gift);
    }
}
