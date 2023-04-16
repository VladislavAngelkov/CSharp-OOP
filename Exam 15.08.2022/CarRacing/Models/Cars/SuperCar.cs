using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double defaultFuelavailable = 80;
        private const double defaultFuelConsumptionPerRace = 10;
        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, defaultFuelavailable, defaultFuelConsumptionPerRace)
        {
        }
    }
}
