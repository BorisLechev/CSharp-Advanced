using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] ordersQuantity = 
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(ordersQuantity);

            Console.WriteLine(ordersQuantity.Max());

            while (queue.Any())
            {
                int order = queue.Peek();

                if (quantityOfFood >= order)
                {
                    quantityOfFood -= order;
                    queue.Dequeue();
                }

                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");

                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
