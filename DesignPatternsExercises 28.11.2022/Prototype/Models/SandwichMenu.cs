namespace Prototype.Models
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichProtoype> sandwiches = new Dictionary<string, SandwichProtoype>();

        public SandwichProtoype this[string sandwichName]
        {
            get
            {
                return sandwiches[sandwichName];
            }
            set
            {
                sandwiches[sandwichName]  = value;
            }
        }
    }
}
