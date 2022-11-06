namespace MilitaryElite.Models
{
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public Engineer(string firstName, string lastName, int id, decimal salary, string corps, List<Repair> repairs) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Repairs = repairs;
        }

        public List<Repair> Repairs
        {
            get { return repairs.AsReadOnly().ToList(); }
            private set
            {
                repairs = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(base.ToString());
            message.AppendLine("Repairs:");
            foreach (var reapair in repairs)
            {
                message.AppendLine(reapair.ToString());
            }

            return message.ToString().TrimEnd();
        }
    }
}
