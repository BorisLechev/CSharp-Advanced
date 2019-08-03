using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> people =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(';');

                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameter = tokens[2];

                if (command == "Add filter")
                {
                    if (!dictionary.ContainsKey(filterType))
                    {
                        dictionary.Add(filterType, new List<string>());
                    }

                    dictionary[filterType].Add(filterParameter);
                }

                else if (command == "Remove filter")
                {
                    dictionary[filterType].Remove(filterParameter);
                }
            }

            foreach (var f in dictionary)
            {
                foreach (string parameter in f.Value)
                {
                    var filter = CreateFilter(f.Key, parameter);
                    people.RemoveAll(filter);
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static Predicate<string> CreateFilter(string type, string parameter)
        {
            switch (type)
            {
                case "Starts with":
                    return x => x.StartsWith(parameter);
                case "Ends with":
                    return x => x.EndsWith(parameter);
                case "Contains":
                    return x => x.Contains(parameter);
                case "Length":
                    return x => x.Length == int.Parse(parameter);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
