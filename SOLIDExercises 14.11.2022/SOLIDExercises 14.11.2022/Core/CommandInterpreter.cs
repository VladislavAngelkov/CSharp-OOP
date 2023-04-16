

namespace Logger.Core
{
    using Models;
    using Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    internal class CommandInterpreter
    {
        private List<IAppender> appenders;

        public CommandInterpreter()
        {
            appenders = new List<IAppender>();
        }

        public void Run()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string appenderType = command[0];
                string layoutType = command[1];
                ILayout layout = Activator.CreateInstance(Type.GetType($"Logger.Models.{layoutType}")) as ILayout;
                string reportLevel;
                IAppender appender = null;

                if (appenderType == "ConsoleAppender")
                {
                    appender = new ConsoleAppender(layout);
                }
                else if (appenderType == "FileAppender")
                {
                    LogFile file = new LogFile();
                    appender = new FileAppender(layout, file);
                }

                if (command.Length == 3)
                {
                    reportLevel= command[2];
                    appender.ReportLevel = reportLevel;
                }

                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            string[] logInfo = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (logInfo[0] != "END")
            {
                string reportLevel = logInfo[0];
                string dateTime = logInfo[1];
                string message = logInfo[2];

                if (reportLevel == "INFO")
                {
                    logger.Info(dateTime, message);
                }
                else if (reportLevel == "WARNING")
                {
                    logger.Warning(dateTime, message);
                }
                else if (reportLevel == "ERROR")
                {
                    logger.Error(dateTime, message);
                }
                else if (reportLevel == "CRITICAL")
                {
                    logger.Critical(dateTime, message);
                }
                else if (reportLevel == "FATAL")
                {
                    logger.Fatal(dateTime, message);
                }

                logInfo = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var appender in appenders)
            {
                Console.WriteLine($"Appender type: {appender.GetType().Name}, Layout type: {appender.Layout.GetType().Name}, Report level: {appender.ReportLevel}, Messages appended: {appender.MessegesCount}");
            }
        }
    }
}
