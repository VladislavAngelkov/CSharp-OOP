using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Formula1.Models
{
    internal class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName= raceName;
            NumberOfLaps= numberOfLaps;
            pilots= new List<IPilot>();
            TookPlace = false;
        }
        public string RaceName
        {
            get 
            { 
                return raceName; 
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return numberOfLaps;
            }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace { get;  set; }

        public ICollection<IPilot> Pilots
        {
            get
            {
                return pilots;
            }
        }

        public void AddPilot(IPilot pilot)
        {
           pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string tookPlaceText;
            if (TookPlace)
            {
                tookPlaceText = "Yes";
            }
            else
            {
                tookPlaceText = "No";
            }
            StringBuilder message = new StringBuilder();
            message.AppendLine($"The {RaceName} race has:");
            message.AppendLine($"Participants: {Pilots.Count}");
            message.AppendLine($"Number of laps: {NumberOfLaps}");
            message.AppendLine($"Took place: {tookPlaceText}");

            return message.ToString().TrimEnd();
        }
    }
}
