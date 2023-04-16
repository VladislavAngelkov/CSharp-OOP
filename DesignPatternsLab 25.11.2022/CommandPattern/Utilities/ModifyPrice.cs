using CommandPattern.Utilities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Utilities
{
    public class ModifyPrice
    {
        private List<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Invoke()
        {
            commands.Add(command);
            command.ExecuteAction();
        }
    }
}
