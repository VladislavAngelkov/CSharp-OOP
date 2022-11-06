namespace MilitaryElite.IO
{
    using System;

    using MilitaryElite.IO.Interfaces;

    class ConsoleWriter : IWriter

    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
