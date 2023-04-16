using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(' ');
            string cmdName = input[0];
            string[] cmdArgs = input.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();

            Type cmdType = assembly.GetTypes().FirstOrDefault(t=>t.Name == $"{cmdName}Command");

            if (cmdType == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            ICommand command = Activator.CreateInstance(cmdType) as ICommand;

            return command.Execute(cmdArgs);
        }
    }
}
