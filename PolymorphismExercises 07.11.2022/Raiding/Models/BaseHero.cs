namespace Raiding.Models
{
    using System;

    using Raiding.Models.Interfaces;
    public abstract class BaseHero : IHero
    {
        private string name;
        protected int power;

        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        public int Power
        {
            get { return power; }
        }

        public abstract string CastAbility();
    }
}
