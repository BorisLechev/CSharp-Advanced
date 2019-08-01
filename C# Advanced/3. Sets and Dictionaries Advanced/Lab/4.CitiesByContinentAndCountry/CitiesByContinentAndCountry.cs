using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.CitiesByContinentAndCountry
{
    class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> dictionary =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                string[] input =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!dictionary.ContainsKey(input[0]))
                {
                    dictionary[input[0]] = new Dictionary<string, List<string>>();
                }

                if (!dictionary[input[0]].ContainsKey(input[1]))
                {
                    dictionary[input[0]][input[1]] = new List<string>();
                }

                dictionary[input[0]][input[1]].Add(input[2]);
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}:");

                foreach (var country in item.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
