using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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
        public int Endurance
        {
            get { return endurance; }
            private set
            {
                if (value<0 || value>100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
                dribble = value;
            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }
                shooting = value;
            }
        }
        public double SkillLevel
        {
            get { return (endurance + sprint + dribble + passing + shooting) / 5.0; }
        }
        public override bool Equals(object obj)
        {
            Player other = obj as Player;

            return this.name == other.name
                && this.endurance == other.endurance
                && this.sprint == other.sprint
                && this.dribble == other.dribble
                && this.passing == other.passing
                && this.shooting == other.shooting;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + endurance + sprint + dribble + passing + shooting;
        }
    }
}
