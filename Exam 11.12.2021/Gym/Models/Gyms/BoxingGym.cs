using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        public const int defaultCapacity = 15;
        public BoxingGym(string name) 
            : base(name, defaultCapacity)
        {
        }
    }
}
