namespace Singleton.Models
{
    using Contracts;
    internal class SingletonDataContainer : ISingletonContainer
    {
        private string path;
        private Dictionary<string, int> cities;
        private static SingletonDataContainer? instance;
        private SingletonDataContainer()
        {
            Console.WriteLine("Initiating ...");
            this.path = "../../../cities.txt";
            string[] citiesInfo = File.ReadAllLines(this.path);
            cities = new Dictionary<string, int>();

            for (int i = 0; i < citiesInfo.Length; i += 2)
            {
                string cityName = citiesInfo[i];
                int population = int.Parse(citiesInfo[i + 1]);

                cities.Add(cityName, population);
            }
        }
        public int GetPopulation(string name)
        {
            return cities[name];
        }

        public static SingletonDataContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonDataContainer();
                }

                return instance;
            }
        }
    }
}
