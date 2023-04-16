namespace Vehicle.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            increasedFuelConsumption = 1.4;
            fuelLeftAfterRefuel = 1;
        }

        public string DriveEmpty(double kilometers)
        {
            increasedFuelConsumption = 0;
            return base.Drive(kilometers);
        }
        public override string Drive(double kilometers)
        {
            increasedFuelConsumption = 1.4;
            return base.Drive(kilometers);
        }
    }
}
