using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _2.HighQualityMistakes
{
    public class Spy
    {
        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            StringBuilder answers = new StringBuilder();

            FieldInfo[] fields =
               classType
               .GetFields(
                   BindingFlags.Instance |
                   BindingFlags.Public |
                   BindingFlags.Static
                   );

            foreach (FieldInfo field in fields)
            {
                answers.AppendLine($"{field.Name} must be private!");
            }

            MethodInfo[] privateMethods = 
                classType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(m => m.Name.StartsWith("get"))
                .ToArray();

            foreach (MethodInfo method in privateMethods)
            {
                answers.AppendLine($"get_Id have to be public!");
            }

            MethodInfo[] publicMethods =
                classType
                .GetMethods(
                    BindingFlags.Public |
                    BindingFlags.Instance
                )
                .Where(m => m.Name.StartsWith("set"))
                .ToArray();

            foreach (MethodInfo method in publicMethods)
            {
                answers.AppendLine($"{method.Name} have to be private!");
            }

            return answers.ToString().TrimEnd();
        }
    }
}
