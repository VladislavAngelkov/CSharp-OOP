namespace BorderControl.Exceptions
{
    using System;
    public class InvalidAgeException : Exception
    {
        private const string InvalidAge = "Age cannot be negative number!";

        public InvalidAgeException()
            : base (InvalidAge)
        {

        }
        public InvalidAgeException(string message)
            : base(message)
        {

        }
    }
}
