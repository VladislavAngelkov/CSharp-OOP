using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class Hero
    {
        private string name;
        private IWeapon weapon;
        private int experience;
        private Hero()
        {
            Experience= 0;
        }
        public Hero(string name, IWeapon weapon)
            : this()
        {
            Name = name;
            Weapon = weapon;
        }

        public string Name
        {
            get { return name; } 
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                name = value;
            }
        }
        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value==null)
                {
                    throw new ArgumentNullException();
                }
                weapon = value;
            }
        }
        public int Experience
        {
            get { return experience; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException();
                }
                experience = value;
            }
        }

        public void Attack(ITarget target)
        {
            weapon.Attack(target);
            target.TakeAttack(weapon.AttackPoints);

            if (target.IsDead())
            {
                Experience += target.GiveExperience();
            }
        }
    }
}
