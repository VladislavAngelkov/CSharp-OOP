using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class ExitCommand : ICommand
    {
        private const int errorCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(errorCode);
            return null;
        }
    }
}
