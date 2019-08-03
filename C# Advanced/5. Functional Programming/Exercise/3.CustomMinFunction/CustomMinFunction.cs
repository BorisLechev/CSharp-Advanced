using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> FindMinNumber = num => num.Min();

            int[] input = 
                Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            Console.WriteLine(FindMinNumber(input));
        }
    }
}