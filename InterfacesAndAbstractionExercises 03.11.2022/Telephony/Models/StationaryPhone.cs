namespace Telephony.Models
{
    using Interfaces;
    using System.Linq;
    using Telephony.Exeptions;
    public class StationaryPhone : ICaller
    {
        public virtual string Call(string number)
        {
            PhoneNumberValidation(number);
            return $"Dialing... {number}";
        }

        protected void PhoneNumberValidation(string number)
        {
            if (number.Any(d => !char.IsDigit(d)))
            {
                throw new InvalidPhoneNumberException();
            }
        }
    }
}
