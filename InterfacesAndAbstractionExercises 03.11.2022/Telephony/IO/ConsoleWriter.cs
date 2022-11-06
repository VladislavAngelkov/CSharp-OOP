

namespace Telephony.IO
{
    using System;

    using Telephony.IO.Inteefaces;
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
