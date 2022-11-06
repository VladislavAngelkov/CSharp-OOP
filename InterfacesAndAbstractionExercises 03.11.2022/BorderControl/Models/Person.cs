
namespace BorderControl.Models
{
    using BorderControl.Exceptions;
    using BorderControl.Models.Interfaces;
    public abstract class Person : ICitizen
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidNameException();
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidAgeException();
                }
                age = value;
            }
        }
    }
}
