namespace Vehicle.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.increasedFuelConsumption = 1.6;
            this.fuelLeftAfterRefuel = 0.95;
        }
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.increasedFuelConsumption = 1.6;
            this.fuelLeftAfterRefuel = 0.95;
        }
    }
}
