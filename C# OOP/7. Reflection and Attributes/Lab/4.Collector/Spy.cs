using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _4.Collector
{
    public class Spy
    {
        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);

            MethodInfo[] methods =
                classType
                .GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.NonPublic |
                    BindingFlags.Public
                    );

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo getter in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (MethodInfo setter in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
