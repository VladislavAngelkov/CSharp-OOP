using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Interfaces
{
    public interface IAppender
    {
        public string ReportLevel { get; set; }
        public void Append(string dateTime, string reportLevel, string message );
        public int MessegesCount { get; }
        public ILayout Layout { get; }
    }
}
