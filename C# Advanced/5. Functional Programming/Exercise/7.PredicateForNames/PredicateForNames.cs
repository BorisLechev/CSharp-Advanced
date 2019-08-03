using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> predicate = name => name.Length <= number;

            foreach (string name in names)
            {
                if (predicate(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
