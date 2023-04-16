using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
            weapons = new List<IWeapon>();
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
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get
            {
                return budget;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get { return CalculateMilitaryPower(); }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get
            {
                return army.AsReadOnly();
            }
        }

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get
            {
                return weapons.AsReadOnly();
            }
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            if (Army.Any(a => a.GetType().Name == unit.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UnitAlreadyAdded, unit.GetType().Name, this.Name));
            }

            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (Weapons.Any(w => w.GetType().Name == weapon.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weapon.GetType().Name, this.Name));
            }

            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Planet: {Name}");
            message.AppendLine($"--Budget: {budget} billion QUID");
            message.AppendLine($"--Forces: {(army.Count != 0 ? string.Join(", ", army.Select(a => a.GetType().Name)) : "No units")}");
            message.AppendLine($"--Combat equipment: {(weapons.Count != 0 ? string.Join(", ", weapons.Select(w => w.GetType().Name)) : "No weapons")}");
            message.AppendLine($"--Military Power: {MilitaryPower}");

            return message.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var armyFroce in army)
            {
                armyFroce.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPower()
        {
            double milPower = Army.Sum(a => a.EnduranceLevel) + Weapons.Sum(w => w.DestructionLevel);

            if (Army.Any(a => a.GetType().Name == "AnonymousImpactUnit"))
            {
                milPower += milPower * 0.3;
            }

            if (Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                milPower += milPower * 0.45;
            }

            milPower = Math.Round(milPower, 3);

            return milPower;
        }
    }
}
