namespace Raiding.Models
{
    public abstract class Hitter : BaseHero
    {
        public Hitter(string name) 
            : base(name)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {power} damage";
        }
    }
}
