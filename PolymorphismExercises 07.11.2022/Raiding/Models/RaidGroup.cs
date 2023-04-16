
namespace Raiding.Models
{
    using System.Collections.Generic;

    using Raiding.IO.Interfaces;
    public class RaidGroup
    {
        private List<BaseHero> group;
        private int boss;
        private IWriter writer;

        public RaidGroup(IWriter writer)
        {
            this.group = new List<BaseHero>();
            this.writer = writer;
        }

        public void AddHero(BaseHero hero)
        {
            this.group.Add(hero);
        }
        public void SetBossHealth(int health)
        {
            this.boss = health;
        }
        public string Fight()
        {
            int dmgSum = 0;

            foreach (var hero in group)
            {
                writer.WriteLine(hero.CastAbility());
                dmgSum += hero.Power;

                if (dmgSum>=boss)
                {
                    return "Victory!";
                }
            }

            return "Defeat...";
        }
    }
}
