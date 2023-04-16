using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    internal class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets= new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            if (!planets.Models.Any(p=>p.Name==planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planets.Models.First(p=>p.Name == planetName);

            if (unitTypeName != "StormTroopers" && unitTypeName != "SpaceForces" && unitTypeName != "AnonymousImpactUnit")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(a=>a.GetType().Name==unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit;
            if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (!planets.Models.Any(p => p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planets.Models.First(p => p.Name == planetName);

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != "SpaceMissiles" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "BioChemicalWeapon")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon;
            if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new BioChemicalWeapon(destructionLevel);    
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(p=>p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(p=>p.MilitaryPower).ThenBy(p=>p.Name)) 
            {
                message.AppendLine(planet.PlanetInfo());
            }

            return message.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.Models.FirstOrDefault(p=>p.Name == planetOne);
            IPlanet secondPlanet = planets.Models.FirstOrDefault(p=> p.Name == planetTwo);

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Weapons.Any(w=>w.GetType().Name== "NuclearWeapon") && secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    return OutputMessages.NoWinner;
                }
                else if (!firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon") && !secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    return OutputMessages.NoWinner;
                }
                else if (firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Army.Sum(a => a.Cost));
                    firstPlanet.Profit(secondPlanet.Weapons.Sum(w => w.Price));

                    planets.RemoveItem(secondPlanet.Name);

                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else
                {
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Army.Sum(a => a.Cost));
                    secondPlanet.Profit(firstPlanet.Weapons.Sum(w => w.Price));

                    planets.RemoveItem(firstPlanet.Name);

                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
            }
            else
            {
                if (firstPlanet.MilitaryPower>secondPlanet.MilitaryPower)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Army.Sum(a => a.Cost));
                    firstPlanet.Profit(secondPlanet.Weapons.Sum(w => w.Price));

                    planets.RemoveItem(secondPlanet.Name);

                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else
                {
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Army.Sum(a => a.Cost));
                    secondPlanet.Profit(firstPlanet.Weapons.Sum(w => w.Price));

                    planets.RemoveItem(firstPlanet.Name);

                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
            }
        }

        public string SpecializeForces(string planetName)
        {
            if (!planets.Models.Any(p=>p.Name == planetName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            IPlanet planet = planets.Models.FirstOrDefault(p=>p.Name == planetName);

            if (planet.Army.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            foreach (var army in planet.Army)
            {
                army.IncreaseEndurance();
            }

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
