using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties();
            foreach ( var property in properties )
            {
                var propValue = property.GetValue(obj);
                var attributes = property.GetCustomAttributes();

                foreach (var attribute in attributes)
                {
                    if (typeof(MyValidationAttribute).IsAssignableFrom(attribute.GetType()))
                    {
                        if (!((MyValidationAttribute)attribute).IsValid(propValue))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
