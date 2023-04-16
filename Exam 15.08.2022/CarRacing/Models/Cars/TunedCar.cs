using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double defaultFuelavailable = 65;
        private const double defaultFuelConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, defaultFuelavailable, defaultFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round(HorsePower * 0.97);
        }
    }
}
