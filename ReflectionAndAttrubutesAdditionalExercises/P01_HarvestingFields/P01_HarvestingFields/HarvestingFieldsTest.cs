namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            var fields = type.GetFields();

            string command = Console.ReadLine();

            while (command != "HARVEST")
            {
                if (command == "public")
                {
                    foreach (var field in fields)
                    {
                        if (field.IsPublic)
                        {
                            Console.WriteLine($"public {field.GetType().Name} {field.Name}");
                        }
                    }
                }
                else if (command == "protected")
                {
                    foreach (var field in fields)
                    {
                        if (field.IsFamily)
                        {
                            Console.WriteLine($"protected {field.GetType().Name} {field.Name}");
                        }
                    }
                }
                else if (command == "private")
                {
                    foreach (var field in fields)
                    {
                        if (field.IsPrivate)
                        {
                            Console.WriteLine($"private {field.GetType().Name} {field.Name}");
                        }
                    }
                }
                else if (command == "all")
                {
                    foreach (var field in fields)
                    {

                        Console.WriteLine($"public {field.GetType().Name} {field.Name}");

                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
