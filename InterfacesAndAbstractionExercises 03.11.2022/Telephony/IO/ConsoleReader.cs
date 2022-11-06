namespace Telephony.IO
{
    using System;

    using Telephony.IO.Inteefaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
