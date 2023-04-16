using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Models
{
    public class FileAppender : Appender
    {
        private LogFile logFile;

        public FileAppender(ILayout layout, LogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, string reportLevel, string message)
        {
            string messageToWrite = string.Format(Layout.Layout, dateTime, reportLevel, message);

            if (IsErrorLevelHighEnought(reportLevel))
            {
                logFile.Write(messageToWrite);

                using (StreamWriter writer = new StreamWriter("../../../log.txt", true))
                {
                    writer.WriteLine(messageToWrite);
                }
                base.Append(dateTime, reportLevel, message);
            }
        }
    }
}
