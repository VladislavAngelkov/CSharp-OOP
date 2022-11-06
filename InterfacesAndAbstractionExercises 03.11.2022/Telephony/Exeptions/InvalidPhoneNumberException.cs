using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exeptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string invalidPhoneNumber = "Invalid number!";



        public InvalidPhoneNumberException()
            : base(invalidPhoneNumber)
        {

        }
        public InvalidPhoneNumberException(string message)
            : base(message)
        {

        }
    }
}