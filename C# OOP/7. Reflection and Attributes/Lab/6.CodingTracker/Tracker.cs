using System;
using System.Linq;
using System.Reflection;

namespace _6.CodingTracker
{
    public class Tracker
    {
        public static void PrintMethodsByAuthor()
        {
            Type classType = typeof(Startup);
            MethodInfo[] methods = 
                classType
                .GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.Static
                );

            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(m => m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
