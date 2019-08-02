using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ",
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).Where(num => num % 2 == 0)
                .OrderBy(num => num)
                .ToArray()));
        }
    }
}
