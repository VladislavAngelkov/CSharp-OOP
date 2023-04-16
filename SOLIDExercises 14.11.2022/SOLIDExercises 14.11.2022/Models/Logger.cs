namespace Logger.Models
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;

    public class Logger : ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }

        public void Critical(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, MethodBase.GetCurrentMethod().Name.ToUpper(), message);
            }
        }

        public void Error(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, MethodBase.GetCurrentMethod().Name.ToUpper(), message);
            }
        }

        public void Fatal(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, MethodBase.GetCurrentMethod().Name.ToUpper(), message);
            }
        }

        public void Info(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, MethodBase.GetCurrentMethod().Name.ToUpper(), message);
            }
        }

        public void Warning(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, MethodBase.GetCurrentMethod().Name.ToUpper(), message);
            }
        }
    }
}
