namespace Vehicle.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.increasedFuelConsumption = 0.9;
            this.fuelLeftAfterRefuel = 1;
        }
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.increasedFuelConsumption = 0.9;
            this.fuelLeftAfterRefuel = 1;
        }
    }
}
