using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    internal class ConsoleAppender : Appender
    {

        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string dateTime, string reportLevel, string message)
        {
            if (IsErrorLevelHighEnought(reportLevel))
            {
                Console.WriteLine(string.Format(Layout.Layout, dateTime, reportLevel, message));
                base.Append(dateTime, reportLevel, message);
            }
        }
    }
}
