
namespace ExplicitInterfaces
{
    using System;

    using ExplicitInterfaces.Engines;
    using ExplicitInterfaces.Engines.Interfaces;
    using ExplicitInterfaces.IO;
    using ExplicitInterfaces.IO.Interfaces;
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
