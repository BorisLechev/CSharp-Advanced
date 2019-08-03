using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] numbers =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int number = int.Parse(Console.ReadLine());

            Func<int, bool> condition = n => n % number != 0;

            numbers = numbers.Where(condition).Reverse().ToArray();

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
