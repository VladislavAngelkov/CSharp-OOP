using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Interfaces
{
    public interface ILogger
    {
        public void Error(string dateTime, string message);
        public void Info(string dateTime, string message);
        public void Fatal(string dateTime, string message);
        public void Warning(string dateTime, string message);
        public void Critical(string dateTime, string message);
    }
}
