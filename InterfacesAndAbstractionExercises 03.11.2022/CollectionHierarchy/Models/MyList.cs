namespace CollectionHierarchy.Models
{
    class MyList : AddRemoveCollection
    {
        public MyList()
            : base()
        {

        }

        public int Used
        {
            get { return collection.Count; }
        }

        public override string Remove()
        {
            if (this.collection.Count > 0)
            {
                string removedElement = collection[0];
                collection.RemoveAt(0);
                return removedElement;
            }
            return null;
        }
    }
}
