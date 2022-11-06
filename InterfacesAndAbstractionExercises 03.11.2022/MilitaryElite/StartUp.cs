namespace MilitaryElite
{
    using MilitaryElite.Engines;
    using MilitaryElite.Engines.Interfaces;
    using MilitaryElite.IO;
    using MilitaryElite.IO.Interfaces;
    using System;
    class StartUp
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
