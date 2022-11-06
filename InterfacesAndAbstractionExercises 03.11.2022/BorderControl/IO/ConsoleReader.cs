namespace BorderControl.IO
{
    using System;

    using BorderControl.IO.Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
