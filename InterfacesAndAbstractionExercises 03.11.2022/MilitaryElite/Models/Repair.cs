namespace MilitaryElite.Models
{
    public class Repair
    {
        private string name;
        private int hours;

        public Repair(string name, int hours)
        {
            Name = name;
            Hours = hours;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
            }
        }
        public int Hours

        {
            get { return hours; }
            private set
            {
                hours = value;
            }
        }

        public override string ToString()
        {
            return $"Part Name: {name} Hours Worked: {hours}";
        }
    }
}
