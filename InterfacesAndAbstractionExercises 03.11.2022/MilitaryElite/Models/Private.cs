
namespace MilitaryElite.Models
{
    using Interfaces;
    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(string firstName, string lastName, int id, decimal salary)
            : base(firstName, lastName, id)
        {
            Salary = salary;
        }

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.salary:f2}";

        }
    }
}
