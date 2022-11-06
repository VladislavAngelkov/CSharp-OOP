namespace BorderControl.Models
{
    using System;

    using BorderControl.Exceptions;
    using BorderControl.Models.Interfaces;
    public class Pet : IBirthable
    {
        private string name;
        private DateTime birthDate;

        public Pet(string name, string birthDate)
        {
            this.Name = name;
            string[] birthInfo = birthDate.Split("/");
            int day = int.Parse(birthInfo[0]);
            int month = int.Parse(birthInfo[1]);
            int year = int.Parse(birthInfo[2]);
            this.BirthDate = new DateTime(year, month, day);
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            private set
            {
                birthDate = value;
            }
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
    }
}
