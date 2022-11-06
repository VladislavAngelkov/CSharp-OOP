

namespace BorderControl.Engines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BorderControl.Engines.Interfaces;
    using BorderControl.Exceptions;
    using BorderControl.IO.Interfaces;
    using BorderControl.Models;
    using BorderControl.Models.Interfaces;
    public class BirthdayCelebrationsEngine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public BirthdayCelebrationsEngine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            List<IBirthable> bDCelebrators = new List<IBirthable>();

            string[] input = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                try
                {
                    if (input[0] == "Citizen")
                    {
                        string name = input[1];
                        int age = int.Parse(input[2]);
                        string id = input[3];
                        string birthDate = input[4];
                        IBirthable citizen = new Citizen(name, age, id, birthDate);
                        bDCelebrators.Add(citizen);
                    }
                    else if (input[0] == "Pet")
                    {
                        string name = input[1];
                        string birthDate = input[2];
                        IBirthable pet = new Pet(name, birthDate);
                        bDCelebrators.Add(pet);
                    }
                }
                catch (InvalidNameException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (InvalidAgeException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (InvalidIdException ex)
                {
                    writer.WriteLine(ex.Message);
                }

                input = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int year = int.Parse(reader.ReadLine());

            foreach (var celebrator in bDCelebrators)
            {
                if (celebrator.BirthDate.Year == year)
                {
                    writer.WriteLine($"{celebrator.BirthDate.Day:D2}/{celebrator.BirthDate.Month:D2}/{celebrator.BirthDate.Year:D4}");
                }
            }
        }
    }
}
