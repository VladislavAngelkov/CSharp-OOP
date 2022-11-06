namespace ExplicitInterfaces.Models.Interfaces
{
    public interface IPerson :INamable
    {
        public int Age { get;}

        public string GetName();
    }
}
