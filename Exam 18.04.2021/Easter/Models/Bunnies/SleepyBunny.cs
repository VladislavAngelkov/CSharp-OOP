using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int defaultEnergy = 50;
        public SleepyBunny(string name) 
            : base(name, defaultEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 15;
        }
    }
}
