namespace MilitaryElite.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary, List<Private> privates) : base(firstName, lastName, id, salary)
        {
            this.Privates = privates;
        }

        public List<Private> Privates
        {
            get { return privates.AsReadOnly().ToList(); }
            private set
            {
                privates = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(base.ToString());
            message.AppendLine("Privates:");
            foreach (var priv in privates)
            {
                message.AppendLine(priv.ToString());
            }

            return message.ToString().TrimEnd();
        }
    }
}
