using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Engines.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models;

namespace WildFarm.Engines
{
    class Engine : IEngine
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
            string[] animalInfo = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Animal> animals = new List<Animal>();

            while (animalInfo[0] != "End")
            {
                Animal animal = AnimalCeator.CreateAnimal(animalInfo);
                animals.Add(animal);

                string[] foodInfo = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (foodInfo[0] == "End")
                {
                    break;
                }
                Food food = FoodCreator.CreateFood(foodInfo);

                writer.WriteLine(animal.ProduceSound());
                
                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }

                animalInfo = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal);
            }
        }
    }
}
