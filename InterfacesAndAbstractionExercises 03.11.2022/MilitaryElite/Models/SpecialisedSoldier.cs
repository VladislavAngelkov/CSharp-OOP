namespace MilitaryElite.Models
{
    using System;

    using MilitaryElite.Enums;
    using MilitaryElite.Exceptions;
    using Interfaces;
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps corps;

        public SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string corps) 
            : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get { return corps.ToString(); }
            private set
            {
                Corps corp;
                if (!Enum.TryParse<Corps>(value, out corp))
                {
                    throw new CorpsException();
                }
                corps = corp;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {corps}";
        }
    }
}
