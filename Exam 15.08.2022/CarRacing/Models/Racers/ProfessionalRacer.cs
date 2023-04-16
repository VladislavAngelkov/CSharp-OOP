using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int defaultGainExperience = 10;
        private const int defaultDrivingExperience = 30;
        private const string defaultRacingBehavior = "strict";
        public ProfessionalRacer(string username, ICar car) 
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
