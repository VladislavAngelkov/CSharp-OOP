namespace Raiding.Models
{
    public class Paladin : Healer
    {
        public Paladin(string name) 
            : base(name)
        {
            this.power = 100;
        }
    }
}
