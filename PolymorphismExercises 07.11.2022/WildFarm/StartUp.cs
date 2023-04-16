﻿
namespace WildFarm
{
    using System;
    using WildFarm.Engines;
    using WildFarm.Engines.Interfaces;
    using WildFarm.IO;
    using WildFarm.IO.Interfaces;

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
