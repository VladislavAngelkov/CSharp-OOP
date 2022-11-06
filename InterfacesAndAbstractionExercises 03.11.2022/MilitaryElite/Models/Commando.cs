
namespace MilitaryElite.Models
{
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;

        public Commando(string firstName, string lastName, int id, decimal salary, string corps, List<Mission> missions) 
            : base(firstName, lastName, id, salary, corps)
        {
            this.Missions = missions;
        }

        public List<Mission> Missions
        {
            get { return missions.AsReadOnly().ToList(); }
            private set
            {
                missions = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(base.ToString());
            message.AppendLine("Missions:");
            foreach (var mission in missions)
            {
                message.AppendLine(mission.ToString());
            }

            return message.ToString().TrimEnd();
        }
    }
}
