namespace ExplicitInterfaces.Models
{
    using System;

    using ExplicitInterfaces.Models.Interfaces;
    public class Citizen : IResident, IPerson
    {
        private string name;
        private int age;
        private string country;

        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be null or whitespace!");
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Age cannot be negative number!");
                }
                age = value;
            }
        }
        public string Country
        {
            get { return country; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be null or whitespace!");
                }
                country = value;
            }
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {name}";
        }
        string IPerson.GetName()
        {
            return name;
        }
    }
}
