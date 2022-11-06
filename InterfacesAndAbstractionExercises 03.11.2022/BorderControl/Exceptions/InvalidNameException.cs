namespace BorderControl.Exceptions
{
    using System;
    public class InvalidNameException : Exception
    {
        private const string InvalidName = "Name cannot be null or whitespace!";

        public InvalidNameException()
            : base(InvalidName)
        {

        }
        public InvalidNameException(string message)
            : base (message)
        {

        }
    }
}
