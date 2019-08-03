using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] dividers =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


        }
    }
}
