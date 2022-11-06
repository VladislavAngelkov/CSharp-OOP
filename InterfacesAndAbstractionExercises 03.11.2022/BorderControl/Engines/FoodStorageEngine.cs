namespace BorderControl.Engines
{
    using System.Collections.Generic;

    using Interfaces;
    using BorderControl.IO.Interfaces;
    using BorderControl.Models.Interfaces;
    using BorderControl.Models;
    using System.Linq;

    public class FoodStorageEngine :IEngine
    {
        private IReader reader;
        private IWriter writer;

        public FoodStorageEngine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            int numberOfPersons = int.Parse(reader.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numberOfPersons; i++)
            {
                string[] personInfo = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

                if (personInfo.Length == 3)
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string group = personInfo[2];
                    IBuyer buyer = new Rebel(name, age, group);

                    buyers.Add(buyer);
                }
                else
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string id = personInfo[2];
                    string birthDate = personInfo[3];
                    IBuyer buyer = new Citizen(name, age, id, birthDate);

                    buyers.Add(buyer);
                }
            }

            string currName = reader.ReadLine();

            while (currName != "End")
            {
                if (buyers.Any(b=>b.Name == currName))
                {
                    buyers.First(b => b.Name == currName).BuyFood();
                }

                currName = reader.ReadLine();
            }

            int totalFood = buyers.Sum(b => b.Food);

            writer.WriteLine(totalFood.ToString());
        }
    }
}
