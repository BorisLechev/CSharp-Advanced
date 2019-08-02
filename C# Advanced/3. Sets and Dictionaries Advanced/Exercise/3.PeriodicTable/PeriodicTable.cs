using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            SortedSet<string> hashSet = new SortedSet<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] compounds =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string compound in compounds)
                {
                    hashSet.Add(compound);
                }
            }

            Console.WriteLine(string.Join(" ", hashSet));
        }
    }
}
