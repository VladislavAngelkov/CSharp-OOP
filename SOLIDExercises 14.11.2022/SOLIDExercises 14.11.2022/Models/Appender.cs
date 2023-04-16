using Logger.Enums;
using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public abstract class Appender : IAppender
    {
        private Reports reportLevelThreshold = Reports.INFO;
        private int messagesCount;

        protected  Appender(ILayout layout) 
        {
            Layout= layout;
        }
        public string ReportLevel
        {
            get 
            {
                return reportLevelThreshold.ToString();
            }
            set
            {
                Enum.TryParse<Reports>(value, out reportLevelThreshold);
            }
        }

        public int MessegesCount
        {
            get
            {
                return messagesCount;
            }
            private set { messagesCount = value; }
        }
        public ILayout Layout { get; private set; }

        public virtual void Append(string dateTime, string reportLevel, string message)
        {
            MessegesCount++;
        }

        protected bool IsErrorLevelHighEnought(string reportLevel)
        {
            Reports currentenReportLevel;
            Enum.TryParse<Reports>(reportLevel, out currentenReportLevel);

            return currentenReportLevel >= reportLevelThreshold;
        }
    }
}
