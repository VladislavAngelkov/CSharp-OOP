namespace CollectionHierarchy.Models
{
    using CollectionHierarchy.Models.Interfaces;
    public class AddRemoveCollection : AddCollection, IRemover
    {
        public AddRemoveCollection()
            : base()
        {

        }
        public virtual string Remove()
        {
            if (this.collection.Count > 0)
            {
                string removedElement = collection[Collection.Count - 1];
                collection.RemoveAt(collection.Count - 1);
                return removedElement;
            }
            return null;
        }

        public override int Add(string element)
        {
            collection.Insert(0, element);
            return 0;
        }
    }
}
