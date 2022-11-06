namespace MilitaryElite.IO
{
    using System;

    using MilitaryElite.IO.Interfaces;
    class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
