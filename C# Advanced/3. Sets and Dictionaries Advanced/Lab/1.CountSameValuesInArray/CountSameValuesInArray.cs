using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountSameValuesInArray
{
    class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            double[] input =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            input.ToList().ForEach(el =>
            {
                if (!dictionary.ContainsKey(el))
                {
                    dictionary.Add(el, 1);
                }

                else
                {
                    dictionary[el]++;
                }
            });

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
