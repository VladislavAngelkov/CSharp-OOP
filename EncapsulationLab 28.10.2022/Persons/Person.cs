using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }
        public decimal Salary
        {
            get { return salary; }
            private set
            {
                //if (value<650)
                //{
                //    throw new ArgumentException("Salary cannot be less than 650 leva!");
                //}
                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (age<30)
            {
                percentage /= 2;
            }

            salary *= (100 + percentage) / 100;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} receives {salary:f2} leva.";
        }
    }
}
