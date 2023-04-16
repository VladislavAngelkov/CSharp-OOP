namespace Raiding.Models
{
    public class Rogue : Hitter
    {
        public Rogue(string name) 
            : base(name)
        {
            this.power = 80;
        }
    }
}
