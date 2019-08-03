using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            Comparison<int> comparison = (x, y) => x % 2 == 0 && y % 2 == 0 ? x - y : x % 2 == 0 ? -1 : y % 2 == 0 ? 1 : x - y;

            int[] input =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(input, comparison);

            Console.WriteLine(String.Join(" ", input));
        }
    }
}
