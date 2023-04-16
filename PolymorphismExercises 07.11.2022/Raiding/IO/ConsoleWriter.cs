namespace Raiding.IO
{
    using Raiding.IO.Interfaces;
    using System;
    public class ConsoleWriter : IWriter
    {
        public void Write(object obj)
        {
            Console.Write(obj.ToString());
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
