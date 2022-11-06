namespace Telephony.Models
{
    using System.Linq;

    using Interfaces;
    using Telephony.Exeptions;
    public class SmartPhone : StationaryPhone, IBrowser
    {
        public string Browse(string url)
        {
            UrlValidation(url);
            return $"Browsing: {url}!";
        }

        protected void UrlValidation(string url)
        {
            if (url.Any(s=>char.IsDigit(s)))
            {
                throw new InvalidURLException();
            }
        }

        public override string Call(string number)
        {
            PhoneNumberValidation(number);
            return $"Calling... {number}";
        }
    }
}
