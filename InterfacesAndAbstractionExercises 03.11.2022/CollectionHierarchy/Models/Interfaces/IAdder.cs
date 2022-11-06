namespace CollectionHierarchy.Models.Interfaces
{
    using System.Collections.Generic;
    public interface IAdder
    {
        public List<string> Collection { get; }
        public int Add(string element);
    }
}
