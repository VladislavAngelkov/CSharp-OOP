namespace Telephony.Exeptions
{
    using System;
    class InvalidURLException : Exception
    {
        private const string InvalidURL = "Invalid URL!";

        public InvalidURLException()
            : base(InvalidURL)
        {

        }

        public InvalidURLException(string message)
            : base(message)
        {

        }
    }
}
