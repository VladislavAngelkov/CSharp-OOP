namespace Telephony.Models.Interfaces
{
    public interface IBrowser : ICaller
    {
        public string Browse(string url);
    }
}
