using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        private int battery;
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.battery = battery;
        }

        public int Battery { get ; set ; }

        public override string ToString()
        {
            return base.ToString()+ $" with {battery} Batteries";
        }
    }
}
