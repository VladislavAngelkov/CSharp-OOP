namespace Raiding.IO
{
    using System;

    using Raiding.IO.Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
