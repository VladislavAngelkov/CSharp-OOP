using Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    {
        public string Layout
        {
            get
            {
                return "{0} - {1} - {2}";
            }
        }
    }
}
