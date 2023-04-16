using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;

        protected Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes= new List<IDye>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                name = value;
            }
        }

        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (value < 0)
                {
                    energy = 0;
                }
                else
                {
                    energy = value;
                }
            }
        }

        public ICollection<IDye> Dyes
        {
            get { return dyes; }
        }

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }

        public abstract void Work();

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Name: {Name}");
            message.AppendLine($"Energy: {Energy}");
            message.AppendLine($"Dyes: {dyes.Where(d => !d.IsFinished()).Count()} not finished");

            return message.ToString().TrimEnd();
        }
    }
}
