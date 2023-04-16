using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logger.Models
{
    public class LogFile
    {
        private StringBuilder sb;
        public LogFile()
        {
            sb = new StringBuilder();
        }

        public void Write(string text)
        {
            sb.AppendLine(text);
        }

        public int Size
        {
            get
            {
                return sb.ToString().Where(c => char.IsLetter(c)).Sum(c => (int)c);
            }
        }
    }
}
