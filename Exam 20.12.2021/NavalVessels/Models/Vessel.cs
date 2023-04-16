using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain capitan;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;
        protected double initialArmorThicknes;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get
            {
                return capitan;
            }
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                capitan = value;
            }
        }
        public double ArmorThickness
        {
            get
            {
                return armorThickness;
            }
            set
            {
                armorThickness= value;
            }
        }

        public double MainWeaponCaliber
        {
            get
            {
                return mainWeaponCaliber;
            }
            protected set
            {
                mainWeaponCaliber= value;
            }
        }

        public double Speed
        {
            get
            {
                return speed;
            }
            protected set
            {
                speed= value;
            }
        }

        public ICollection<string> Targets
        {
            get
            {
                return targets;
            }
        }

        public void Attack(IVessel target)
        {
            if (target==null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= MainWeaponCaliber;

            if (target.ArmorThickness<0)
            {
                target.ArmorThickness = 0;
            }

            targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            ArmorThickness = initialArmorThicknes;
        }


        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"- {Name}");
            message.AppendLine($" *Type: {this.GetType().Name}");
            message.AppendLine($" *Armor thickness: {ArmorThickness}");
            message.AppendLine($" *Main weapon caliber: {mainWeaponCaliber}");
            message.AppendLine($" *Speed: {Speed} knots");
            message.AppendLine($" *Targets: {(Targets.Count == 0 ? "None" : string.Join(", ", Targets))}");

            return message.ToString().TrimEnd();
        }
    }
}
