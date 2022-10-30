using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string type = Console.ReadLine();

            while (type != "Beast!")
            {
                try
                {
                    string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = "";
                    int age = 0;
                    string gender = "";

                    if (animalInfo.Length == 3)
                    {
                        name = animalInfo[0];
                        age = int.Parse(animalInfo[1]);
                        gender = animalInfo[2];
                    }
                    else
                    {
                        name = animalInfo[0];
                        age = int.Parse(animalInfo[1]);
                    }

                    switch (type)
                    {
                        case "Cat":
                            Cat cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;
                        case "Dog":
                            Dog dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;
                        case "Frog":
                            Frog frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;
                        case "Kitten":
                            Kitten kittens = new Kitten(name, age);
                            animals.Add(kittens);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            animals.Add(tomcat);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                type = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
