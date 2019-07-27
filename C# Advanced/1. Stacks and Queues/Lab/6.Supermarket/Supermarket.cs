using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket
{
    class SuperMarket
    {
        static void Main(string[] args)
        {
            string input = String.Empty;
            Queue<string> queue = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    foreach (string item in queue)
                    {
                        Console.WriteLine(item);
                    }

                    queue.Clear();
                }

                else
                {
                    queue.Enqueue(input);
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
