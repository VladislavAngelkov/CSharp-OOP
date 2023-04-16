namespace Raiding.Engines
{
    using System;

    using Interfaces;
    using Raiding.IO.Interfaces;
    using Raiding.Models;

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
            int numberOfHeroes = int.Parse(reader.ReadLine());

            RaidGroup heroes = new RaidGroup(writer);

            for (int i = 0; i < numberOfHeroes*2; i+=2)
            {
                string name = reader.ReadLine();
                string type = reader.ReadLine();
                try
                {
                    heroes.AddHero(HeroCreator.CreateHero(type, name));
                }
                catch (ArgumentException ex)
                {
                    i -= 2;
                    writer.WriteLine(ex.Message);
                }
            }

            heroes.SetBossHealth(int.Parse(reader.ReadLine()));

            writer.WriteLine(heroes.Fight());
        }
    }
}
