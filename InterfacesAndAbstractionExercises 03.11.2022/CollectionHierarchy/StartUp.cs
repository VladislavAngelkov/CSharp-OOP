
namespace CollectionHierarchy
{
    using CollectionHierarchy.Engines;
    using CollectionHierarchy.Engines.Interfaces;
    using CollectionHierarchy.IO;
    using CollectionHierarchy.IO.Interfaces;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
