using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
           return obj!=null;
        }
    }
}
