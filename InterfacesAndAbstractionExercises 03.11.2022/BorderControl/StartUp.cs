namespace BorderControl
{
    using BorderControl.Engines;
    using BorderControl.IO;
    using BorderControl.IO.Interfaces;
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            //BorderControlEngine engine = new BorderControlEngine(reader, writer);
            //BirthdayCelebrationsEngine engine = new BirthdayCelebrationsEngine(reader, writer);
            FoodStorageEngine engine = new FoodStorageEngine(reader, writer);
            engine.Run();
        }
    }
}
