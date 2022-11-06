
namespace MilitaryElite.Models
{
    using Interfaces;
    using MilitaryElite.Exceptions;

    public abstract class Soldier : ISoldier
    {
        private string firstName;
        private string lastName;
        private int id;

        protected Soldier(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NameException();
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NameException();
                }
                lastName = value;
            }
        }

        public int Id
        {
            get { return id; }
            private set
            {
                id = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.firstName} {this.lastName} Id: {this.id}";
        }
    }
}
