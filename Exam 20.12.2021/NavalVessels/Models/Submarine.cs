using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double maxArmorThickness = 200;
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, maxArmorThickness)
        {
            submergeMode = false;
            initialArmorThicknes = maxArmorThickness;
        }

        public bool SubmergeMode
        {
            get
            {
                return submergeMode;
            }
        }

        public void ToggleSubmergeMode()
        {
            submergeMode = !submergeMode;

            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }
        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(base.ToString());
            message.AppendLine($" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}");

            return message.ToString().TrimEnd();
        }
    }
}
