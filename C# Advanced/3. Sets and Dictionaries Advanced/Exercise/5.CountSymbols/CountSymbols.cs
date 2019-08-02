using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!dictionary.ContainsKey(input[i]))
                {
                    dictionary.Add(input[i], 0);
                }

                dictionary[input[i]]++;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
