namespace Vehicle.Models
{
    using System;
    public class VehicleCreator
    {
        public Vehicle CreateVehicle(string info)
        {
            string type = info.Split("", StringSplitOptions.RemoveEmptyEntries)[0];
            if (type == "Car")
            {
                return CreateCar(info);
            }
            else if (type == "Truck")
            {
                return CreateTruck(info);
            }
            else if (type == "Bus")
            {
                return CreateBus(info);
            }
            else
            {
                throw new ArgumentException("Invalid vehicle type!");
            }
        }
        private Car CreateCar( string info)
        {
            string[] carInfo = info.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            if (carInfo.Length == 3)
            {
                Car car = new Car(carFuelQuantity, carFuelConsumption);
                return car;
            }
            else
            {
                double carTankCapacity = double.Parse(carInfo[3]);
                Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
                return car;
            }
        }

        private Truck CreateTruck(string info)
        {
            string[] truckInfo = info.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            if (truckInfo.Length == 3)
            {
                Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);
                return truck;
            }
            else
            {
                double truckTankCapacity = double.Parse(truckInfo[3]);
                Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
                return truck;
            }
        }
        private Bus CreateBus(string info)
        {
            string[] busInfo = info.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            return bus;
        }
    }
}
