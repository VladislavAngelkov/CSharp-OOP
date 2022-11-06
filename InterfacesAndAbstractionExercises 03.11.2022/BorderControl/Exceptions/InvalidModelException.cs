namespace BorderControl.Exceptions
{
    using System;
    public class InvalidModelException : Exception
    {
        private const string InvalidModel = "Model cannot be null or whitespace!";

        public InvalidModelException()
            :base (InvalidModel)
        {

        }
        public InvalidModelException(string message)
            :base(message)
        {

        }
    }
}
