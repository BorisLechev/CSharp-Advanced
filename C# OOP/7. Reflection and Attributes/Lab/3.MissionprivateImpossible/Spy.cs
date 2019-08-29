using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _3.MissionprivateImpossible
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");

            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] privateMethods =
                classType
                .GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.NonPublic
                    );

            foreach (MethodInfo privateMethod in privateMethods)
            {
                sb.AppendLine(privateMethod.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
