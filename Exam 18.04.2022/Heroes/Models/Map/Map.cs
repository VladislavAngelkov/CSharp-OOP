using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        private List<IHero> knights;
        private List<IHero> barbarians;
        public string Fight(ICollection<IHero> players)
        {
            knights = players.Where(p=>p.GetType().Name == "Knight").ToList();
            barbarians = players.Where(p => p.GetType().Name == "Barbarian").ToList();

            while (knights.Any(k=>k.IsAlive) && barbarians.Any(b=>b.IsAlive))
            {
                foreach (var knight in knights.Where(k=>k.IsAlive && k.Weapon.Durability!=0))
                {
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        int dmg = knight.Weapon.DoDamage();
                        barbarian.TakeDamage(dmg);
                    }
                }

                foreach (var barbarian in barbarians.Where(b=>b.IsAlive && b.Weapon.Durability != 0))
                {
                    foreach (var knight in knights.Where(k=>k.IsAlive))
                    {
                        int dmg = barbarian.Weapon.DoDamage();
                        knight.TakeDamage(dmg);
                    }
                }
            }

            if (knights.Any(k=>k.IsAlive))
            {
                return $"The knights took {knights.Where(k=>!k.IsAlive).Count()} casualties but won the battle.";
            }

            return $"The barbarians took {barbarians.Where(b=>!b.IsAlive).Count()} casualties but won the battle.";
        }
    }
}
