namespace Vehicle.Engines
{
    using Interfaces;
    using IO.Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            VehicleCreator factory = new VehicleCreator();
            Vehicle car = factory.CreateVehicle( reader.ReadLine());

            Vehicle truck = factory.CreateVehicle(reader.ReadLine());

            Vehicle bus = factory.CreateVehicle(reader.ReadLine()); 

            int numberOfCommands = int.Parse(reader.ReadLine());

            VehicleUser user = new VehicleUser(car, truck, bus, writer);

            for (int i = 0; i < numberOfCommands; i++)
            {
                user.UseVehicle(reader.ReadLine());
            }

            writer.WriteLine($"Car: {car.FuelQuantity:f2}");
            writer.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            writer.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
