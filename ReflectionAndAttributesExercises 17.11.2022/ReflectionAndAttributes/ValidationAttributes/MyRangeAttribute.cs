using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            Type type = obj.GetType();
            if (!typeof(int).IsAssignableFrom(type))
            {
                throw new ArgumentException("Argument must be integer!");
            }

            int value = (int)obj;

            return value >= minValue && value <= maxValue;
        }
    }
}
