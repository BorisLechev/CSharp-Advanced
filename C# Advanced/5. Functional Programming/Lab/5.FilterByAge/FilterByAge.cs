using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < number; i++)
            {
                string[] person =
                    Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                dictionary.Add(person[0], int.Parse(person[1]));
            }

            string condition = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<KeyValuePair<string, int>, bool> tester = CreateTester(condition, conditionAge);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            dictionary
                .Where(tester)
                .ToList()
                .ForEach(printer);
        }

        private static Func<KeyValuePair<string, int>, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x.Value < age;
                case "older":
                    return x => x.Value >= age;
                default:
                    return null;
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine(person.Key);
                case "age":
                    return person => Console.WriteLine(person.Value);
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default:
                    return null;
            }
        }
    }
}
