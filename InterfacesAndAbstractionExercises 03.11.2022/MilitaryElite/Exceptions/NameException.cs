
namespace MilitaryElite.Exceptions
{
    using System;
    public class NameException : Exception
    {
        private const string NullOrWhiteSpace = "Name cannot be null or whitespace!";
        public NameException()
        :base(NullOrWhiteSpace)
        {

        }
        public NameException(string message)
            : base(message)
        {

        }
    }
}
