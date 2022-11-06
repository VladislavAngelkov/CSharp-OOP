using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Round(players.Sum(p => p.SkillLevel) / players.Count, 0);
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string player)
        {
            if (!players.Any(p=>p.Name==player))
            {
                throw new ArgumentException($"Player {player} is not in {name} team.");
            }

            players.Remove(players.First(p => p.Name == player));
        }

        public override string ToString()
        {
            return $"{name} - {Rating}";
        }
    }
}
