using Singleton.Models;

SingletonDataContainer cities1 = SingletonDataContainer.Instance;
Console.WriteLine(cities1.GetPopulation("Sofia"));
SingletonDataContainer cities2 = SingletonDataContainer.Instance;
Console.WriteLine(cities1.GetPopulation("Sofia"));
SingletonDataContainer cities3 = SingletonDataContainer.Instance;
Console.WriteLine(cities1.GetPopulation("Sofia"));
SingletonDataContainer cities4 = SingletonDataContainer.Instance;
Console.WriteLine(cities1.GetPopulation("Sofia"));
