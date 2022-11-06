namespace BorderControl.Exceptions
{
    using System;
    public class InvalidIdException : Exception
    {
        private const string InvalidID = "ID cannot be null or whitespace!";

        public InvalidIdException()
            : base(InvalidID)
        {

        }
        public InvalidIdException(string message)
            :base(message)
        {

        }
    }
}
