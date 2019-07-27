using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string input = String.Empty;
            Queue<string> queue = new Queue<string>();
            int passedCars = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }

                else
                {
                    int counter = number;

                    while (counter > 0 && queue.Count > 0)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter--;
                        passedCars++;
                    }
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
