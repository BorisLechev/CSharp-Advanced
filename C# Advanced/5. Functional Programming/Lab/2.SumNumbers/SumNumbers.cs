using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = num => int.Parse(num);
            
            int[] numbers =
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
