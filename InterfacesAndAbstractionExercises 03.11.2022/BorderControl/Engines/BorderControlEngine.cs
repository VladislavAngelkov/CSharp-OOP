namespace BorderControl.Engines
{
    using System;

    using Interfaces;
    using BorderControl.IO.Interfaces;
    using System.Collections.Generic;
    using BorderControl.Models.Interfaces;
    using BorderControl.Models;
    using BorderControl.Exceptions;

    public class BorderControlEngine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public BorderControlEngine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            List<IIDentifiable> citizens = new List<IIDentifiable>();

            string[] input = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                try
                {
                    if (input.Length == 2)
                    {
                        string model = input[0];
                        string id = input[1];
                        IIDentifiable robot = new Robot(model, id);
                        citizens.Add(robot);
                    }
                    else
                    {
                        string name = input[0];
                        int age = int.Parse(input[1]);
                        string id = input[2];
                        IIDentifiable person = new Citizen(name, age, id);
                        citizens.Add(person);
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
                catch (InvalidModelException ex)
                {
                    writer.WriteLine(ex.Message);
                }

                input = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string fakeIdEnd = reader.ReadLine();
            int fakeIdLength = fakeIdEnd.Length;

            List<string> fakeIds = new List<string>();

            foreach (var citizen in citizens)
            {
                if (citizen.Id.Substring(citizen.Id.Length-fakeIdLength, fakeIdLength) == fakeIdEnd)
                {
                    fakeIds.Add(citizen.Id);
                }
            }

            foreach (var fakeId in fakeIds)
            {
                writer.WriteLine(fakeId);
            }
        }
    }
}
