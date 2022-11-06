namespace CollectionHierarchy.Models
{
    using System.Linq;
    using System.Collections.Generic;

    using CollectionHierarchy.Models.Interfaces;
    public class AddCollection : IAdder
    {
        protected List<string> collection;
        public AddCollection()
        {
            collection = new List<string>();
        }
        public List<string> Collection
        {
            get { return collection.AsReadOnly().ToList(); }
        }

        public virtual int Add(string element)
        {
            collection.Add(element);
            return collection.Count - 1;
        }
    }
}
