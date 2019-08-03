using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> print = el => Console.WriteLine($"Sir {el}");

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }
    }
}
