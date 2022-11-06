namespace ExplicitInterfaces.Engines
{
    using System.Collections.Generic;

    using Interfaces;
    using ExplicitInterfaces.IO.Interfaces;
    using ExplicitInterfaces.Models;
    using ExplicitInterfaces.Models.Interfaces;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] personInfo = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            List<Citizen> citizens = new List<Citizen>();

            while (personInfo[0] != "End")
            {
                string name = personInfo[0];
                string country = personInfo[1];
                int age = int.Parse(personInfo[2]);

                Citizen citizen = new Citizen(name, age, country);
                citizens.Add(citizen);
                
                personInfo = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var citizen in citizens)
            {
                IPerson person = citizen;
                IResident resident = citizen;

                writer.WriteLine(person.GetName());
                writer.WriteLine(resident.GetName());
            }
        }
    }
}
