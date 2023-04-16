namespace Raiding.Models
{
    public class Druid : Healer
    {
        public Druid(string name) 
            : base(name)
        {
            this.power = 80;
        }
    }
}
