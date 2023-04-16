using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsToInvastigete)
        {
            Type type = Type.GetType(className);
            object obj = Activator.CreateInstance(type);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder message = new StringBuilder();
            message.AppendLine($"Class under investigation: {type.Name}");

            foreach (var field in fields)
            {
                if (fieldsToInvastigete.Any(f => f == field.Name))
                {
                    object fieldValue = field.GetValue(obj);
                    message.AppendLine($"{field.Name} = {fieldValue}");
                }
            }

            return message.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder message = new StringBuilder();

            foreach (var field in fields)
            {
                message.AppendLine($"{field.Name} must be private!");
            }

            foreach (var prop in properties)
            {
                MethodInfo getMethod = prop.GetGetMethod(true);
                if (getMethod.IsPrivate)
                {
                    message.AppendLine($"{getMethod.Name} have to be public!");
                }
            }

            foreach (var prop in properties)
            {
                MethodInfo setMethod = prop.GetSetMethod(false);
                if (setMethod != null)
                {
                    message.AppendLine($"{setMethod.Name} have to be private!");
                }
            }

            return message.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder message = new StringBuilder();
            message.AppendLine($"All Private Methods of Class: {className}");
            message.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (var method in methods)
            {
                message.AppendLine(method.Name);
            }

            return message.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            StringBuilder message = new StringBuilder();

            foreach (var prop in properties)
            {
                MethodInfo getMethod = prop.GetGetMethod(true);
                Type returnType = getMethod.ReturnType;

                message.AppendLine($"{getMethod.Name} will return {returnType.FullName}");
            }

            foreach (var prop in properties)
            {
                MethodInfo setMethod = prop.GetSetMethod(true);

                message.AppendLine($"{setMethod.Name} will set field of {setMethod.GetParameters().First().ParameterType}");
            }

            return message.ToString().TrimEnd();
        }
    }
}
