namespace Vehicle.IO
{
    using System;

    using IO.Interfaces;

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
