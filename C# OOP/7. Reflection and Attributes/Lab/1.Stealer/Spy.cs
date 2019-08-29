using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _1.Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] namesOfTheFieldsToInvestigate)
        {
            Type classType = Type.GetType(nameOfClass);

            FieldInfo[] fields = 
                classType
                .GetFields (
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance
                )
                .Where(f => namesOfTheFieldsToInvestigate.Contains(f.Name))
                .ToArray();

            var classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (FieldInfo field in fields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
