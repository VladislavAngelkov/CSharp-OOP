using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
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
                    throw new ArgumentException("Age cannot be negative number!");
                }
                age = value;
            }
        }

        public string Id
        {
            get { return id; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ID cannot be null or whitespace!");
                }
                id = value;
            }
        }

        public string Birthdate
        {
            get { return birthdate; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Birthdate cannot be null or whitespace!");
                }
                birthdate = value;
            }

        }
    }
}
