
namespace BorderControl.Models
{
    using BorderControl.Exceptions;
    using BorderControl.Models.Interfaces;
    public class Rebel : Person, IRebel, IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name, int age, string group)
            :base(name, age)
        {
            this.Group = group;
            this.food = 0;
        }
        
        public string Group
        {
            get { return group; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidNameException();
                }
                group = value;
            }
        }

        public int Food
        {
            get { return food; }
        }

        public void BuyFood()
        {
            this.food += 5;
        }
    }
}
