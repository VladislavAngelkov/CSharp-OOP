namespace Raiding.Models
{
    public abstract class Healer : BaseHero
    {
        protected Healer(string name) : base(name)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {power}";
        }
    }
}
