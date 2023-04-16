namespace Vehicle.Models
{
    using System;

    using IO.Interfaces;
    class VehicleUser
    {
        private Vehicle car;
        private Vehicle truck;
        private Vehicle bus;
        private IWriter writer;

        public VehicleUser(Vehicle car, Vehicle truck, IWriter writer)
        {
            this.car = car;
            this.truck = truck;
            this.writer = writer;
        }
        public VehicleUser(Vehicle car, Vehicle truck, Vehicle bus, IWriter writer)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
            this.writer = writer;
        }

        public void UseVehicle(string info)
        {
            string[] commandInfo = info.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandInfo[0];
            string vehicle = commandInfo[1];
            double value = double.Parse(commandInfo[2]);

            if (command == "Drive")
            {
                if (vehicle == "Car")
                {
                    writer.WriteLine(car.Drive(value));
                }
                else if (vehicle == "Truck")
                {
                    writer.WriteLine(truck.Drive(value));
                }
                else if (vehicle == "Bus")
                {
                    writer.WriteLine(bus.Drive(value));
                }
            }
            else if (command == "Refuel")
            {
                if (vehicle == "Car")
                {
                    string refuelMessage = car.Refuel(value);
                    if (refuelMessage != null)
                    {
                        writer.WriteLine(refuelMessage);
                    }
                }
                else if (vehicle == "Truck")
                {
                    string refuelMessage = truck.Refuel(value);
                    if (refuelMessage != null)
                    {
                        writer.WriteLine(refuelMessage);
                    }
                }
                else if (vehicle == "Bus")
                {
                    string refuelMessage = bus.Refuel(value);
                    if (refuelMessage != null)
                    {
                        writer.WriteLine(refuelMessage);
                    }
                }
            }
            else if (command == "DriveEmpty")
            {
                
                writer.WriteLine(((Bus)bus).DriveEmpty(value));
            }
        }
    }
}
