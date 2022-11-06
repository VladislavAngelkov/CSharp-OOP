namespace BorderControl.Models
{
    using System;

    using BorderControl.Exceptions;
    using Interfaces;
    public class Citizen : Person, IBirthable, IBuyer, IIDentifiable
    {
        private string name;
        private int age;
        private string id;
        private DateTime birthDate;
        private int food;

        public Citizen(string name, int age, string id)
            :base(name, age)
        {
            this.Id = id;
            this.food = 0;
        }

        public Citizen(string name, int age, string id, string birthDate)
            : this (name, age, id)
        {
            string[] birthInfo = birthDate.Split("/");
            int day = int.Parse(birthInfo[0]);
            int month = int.Parse(birthInfo[1]);
            int year = int.Parse(birthInfo[2]);
            this.BirthDate = new DateTime(year, month, day);
        }
        public string Id
        {
            get { return id; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidNameException();
                }
                id = value;
            }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            private set
            {
                birthDate = value;
            }
        }
        public int Food
        {
            get { return food; }
        }
        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
