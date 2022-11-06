namespace CollectionHierarchy.Engines
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using CollectionHierarchy.IO.Interfaces;
    using CollectionHierarchy.Models.Interfaces;
    using CollectionHierarchy.Models;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private List<IAdder> collections;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            collections = new List<IAdder>();
            collections.Add(new AddCollection());
            collections.Add(new AddRemoveCollection());
            collections.Add(new MyList());
        }

        public void Run()
        {
            string[] elements = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int removeElements = int.Parse(reader.ReadLine());

            foreach (var collection in collections)
            {
                foreach (var element in elements)
                {
                    writer.Write(collection.Add(element).ToString() + " ");
                }
                writer.WriteLine("");
            }

            

            foreach (var collection in collections)
            {
                if (collection is IRemover)
                {
                    for (int i = 0; i < removeElements; i++)
                    {
                        var newCollection = collection as IRemover;
                        writer.Write(newCollection.Remove() + " ");
                    }
                    writer.WriteLine("");
                }
            }
        }
    }
}
