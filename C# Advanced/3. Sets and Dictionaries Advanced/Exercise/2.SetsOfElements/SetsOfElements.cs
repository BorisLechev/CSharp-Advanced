using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] setsSize =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> firstHashSet = new HashSet<int>();
            HashSet<int> secondHashSet = new HashSet<int>();

            for (int i = 0; i < setsSize[0]; i++)
            {
                firstHashSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < setsSize[1]; i++)
            {
                secondHashSet.Add(int.Parse(Console.ReadLine()));
            }

            List<int> uniqueNumbers = new List<int>();

            foreach (int item in firstHashSet)
            {
                if (secondHashSet.Contains(item))
                {
                    uniqueNumbers.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueNumbers));
        }
    }
}
