using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            double[] prices =
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(price => price * 1.2)
                .ToArray();

            foreach (double price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
