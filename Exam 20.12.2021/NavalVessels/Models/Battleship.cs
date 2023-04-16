using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double maxArmorThickness = 300;
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, maxArmorThickness)
        {
            sonarMode = false;
            initialArmorThicknes = maxArmorThickness;
        }

        public bool SonarMode
        {
            get 
            { 
                return sonarMode; 
            }
        }
        
        public void ToggleSonarMode()
        {
            sonarMode = !sonarMode;

            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
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
            message.AppendLine($" *Sonar mode: {(SonarMode ? "ON" : "OFF")}");

            return message.ToString().TrimEnd();
        }
    }
}
