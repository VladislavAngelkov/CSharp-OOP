
namespace Vehicle.Models
{
    using System;
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double traveledDistance;
        protected double increasedFuelConsumption;
        protected double fuelLeftAfterRefuel = 1;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : this(fuelQuantity, fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            if (fuelQuantity>tankCapacity)
            {
                this.fuelQuantity = 0;
            }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel quantity cannot be negative number!");
                }
                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be negative number!");
                }
                fuelConsumption = value;
            }
        }
        public double TraveledDistance
        {
            get { return traveledDistance; }
            private set
            {
                traveledDistance = value;
            }
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            private set
            {
                tankCapacity = value;
            }
        }

        public virtual string Drive(double kilometers)
        {
            double fuelNeeded = (FuelConsumption + increasedFuelConsumption) * kilometers;

            if (fuelNeeded>FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            TraveledDistance += kilometers;
            FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }
        public string Refuel(double litters)
        {
            if (litters<=0)
            {
                return "Fuel must be a positive number";
            }
            else if (litters + fuelQuantity>tankCapacity)
            {
                return $"Cannot fit {litters} fuel in the tank";
            }

            FuelQuantity += litters * fuelLeftAfterRefuel;
            return null;
        }
    }
}
