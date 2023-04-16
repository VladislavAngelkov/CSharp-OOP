using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    internal class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models
        {
            get
            {
                return models.AsReadOnly();
            }
        }

        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(p => p.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            if (models.Any(p => p.Name == name))
            {
                IPlanet armyToRemove = models.FirstOrDefault(p =>p.Name == name);
                models.Remove(armyToRemove);

                return true;
            }

            return false;
        }
    }
}
