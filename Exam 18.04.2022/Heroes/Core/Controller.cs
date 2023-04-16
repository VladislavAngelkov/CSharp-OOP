using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes= new HeroRepository();
            weapons= new WeaponRepository();
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.Models.FirstOrDefault(h => h.Name == heroName);
            IWeapon weapon = weapons.Models.FirstOrDefault(w=> w.Name == weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }

            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon!=null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            weapons.Remove(weapon);
            hero.AddWeapon(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(h=>h.Name==name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            if (type != "Knight" && type != "Barbarian")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return $"Successfully added Barbarian {name} to the collection.";
            }
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(w => w.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }

            IWeapon weapon;

            if (type == "Mace")
            {
                weapon = new Mace(name, durability);
                weapons.Add(weapon);
            }
            else
            {
                weapon = new Claymore(name, durability);
                weapons.Add(weapon);
            }

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {
            StringBuilder message = new StringBuilder();

            foreach (var hero in heroes.Models.OrderBy(h=>h.GetType().Name).ThenByDescending(h=>h.Health).ThenBy(h=>h.Name))
            {
                message.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                message.AppendLine($"--Health: {hero.Health}");
                message.AppendLine($"--Armour: {hero.Armour}");
                message.AppendLine($"--Weapon: {(hero.Weapon != null ? hero.Weapon.Name : "Unarmed")}");
            }
            
            return message.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();

            string message = map.Fight(heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList());

            return message;
        }
    }
}
