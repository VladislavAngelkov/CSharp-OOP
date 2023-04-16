namespace WildFarm.Models
{
    using System;
    public static class AnimalCeator
    {
        public static Animal CreateAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            Animal animal;

            switch (type)
            {
                case "Owl":
                    animal = new Owl(name, weight, double.Parse(animalInfo[3]));
                    break;
                case "Hen":
                    animal = new Hen(name, weight, double.Parse(animalInfo[3]));
                    break;
                case "Mouse":
                    animal = new Mouse(name, weight, animalInfo[3]);
                    break;
                case "Dog":
                    animal = new Dog(name, weight, animalInfo[3]);
                    break;
                case "Cat":
                    animal = new Cat(name, weight, animalInfo[3], animalInfo[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(name, weight, animalInfo[3], animalInfo[4]);
                    break;
                default:
                    throw new ArgumentException("Invalid animal type!");
            }

            return animal;
        }
    }
}
