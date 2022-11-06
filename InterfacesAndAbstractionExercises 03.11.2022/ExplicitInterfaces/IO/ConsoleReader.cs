namespace ExplicitInterfaces.IO
{
    using System;

    using ExplicitInterfaces.IO.Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
