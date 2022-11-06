namespace ExplicitInterfaces.Models.Interfaces
{
    public interface IResident : INamable
    {
        public string Country { get;}

        public string GetName();
    }
}
