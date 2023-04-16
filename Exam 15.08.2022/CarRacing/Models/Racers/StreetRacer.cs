using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int defaultGainExperience = 5;
        private const int defaultDrivingExperience = 10;
        private const string defaultRacingBehavior = "aggressive";
        public StreetRacer(string username, ICar car)
            : base(username, defaultRacingBehavior, defaultDrivingExperience, car)
        {

        }

        public override void Race()
        {
            if (IsAvailable())
            {
                base.Race();
                DrivingExperience += defaultGainExperience;
            }
        }
    }
}
