namespace Raiding.Models
{
    public class Warrior : Hitter
    {
        public Warrior(string name) 
            : base(name)
        {
            this.power = 100;
        }
    }
}
