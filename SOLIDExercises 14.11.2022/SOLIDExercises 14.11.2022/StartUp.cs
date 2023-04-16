namespace Logger
{
    using System;
    using System.Data;
    using Logger.Core;
    using Models;
    using Models.Interfaces;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            CommandInterpreter interpreter = new CommandInterpreter();
            interpreter.Run();

        }
    }
}
