using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    internal class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models
        {
            get
            {
                return models.AsReadOnly();
            }
        }

        public void AddItem(IMilitaryUnit model)
        {
            models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return models.FirstOrDefault(a => a.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            if (models.Any(a => a.GetType().Name == name))
            {
                IMilitaryUnit armyToRemove = models.FirstOrDefault(a => a.GetType().Name == name);
                models.Remove(armyToRemove);

                return true;
            }

            return false;
        }
    }
}
