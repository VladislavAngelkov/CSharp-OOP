namespace Telephony
{
    using Telephony.IO.Inteefaces;
    using Telephony.IO;
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engines.Engine engine = new Engines.Engine(reader, writer);
            engine.Run();
        }
    }
}
