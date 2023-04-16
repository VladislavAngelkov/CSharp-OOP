using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private int exploredPlanetsCount = 0;
        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> explorers = astronauts.Models.Where(m => m.Oxygen > 60).ToList();

            if (explorers.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = planets.FindByName(planetName);

            Mission mission = new Mission();
            mission.Explore(planet, explorers);
            exploredPlanetsCount++;

            int deadExplorers = explorers.Where(e=>!e.CanBreath).Count();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadExplorers);
        }

        public string Report()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{exploredPlanetsCount} planets were explored!");
            message.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                message.AppendLine($"Name: {astronaut.Name}");
                message.AppendLine($"Oxygen: {astronaut.Oxygen}");
                message.AppendLine($"Bag items: {(astronaut.Bag.Items.Count!=0 ? string.Join(", ", astronaut.Bag.Items) : "none")}");
            }

            return message.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
