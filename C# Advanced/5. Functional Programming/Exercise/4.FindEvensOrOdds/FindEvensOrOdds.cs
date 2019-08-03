using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] numbers =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Predicate<int> filter = Predicate(command);

            List<int> list = new List<int>();

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (filter(i))
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(String.Join(" ", list));
        }

        private static Predicate<int> Predicate(string evenOrOdd)
        {
            if (evenOrOdd == "even")
            {
                return n => n % 2 == 0;
            }

            else if (evenOrOdd == "odd")
            {
                return n => n % 2 != 0;
            }

            throw new NotImplementedException();
        }
    }
}
