
namespace MilitaryElite.Models
{
    using System.Text;

    using Interfaces;

    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public Spy(string firstName, string lastName, int id, int codeNumber) 
            : base(firstName, lastName, id)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber
        {
            get { return codeNumber; }
            private set
            {
                codeNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
            message.Append($"Code Number: {codeNumber}");

            return message.ToString().TrimEnd();
        }
    }
}
