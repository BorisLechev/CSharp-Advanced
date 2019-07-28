using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FashionBoutigue
{
    class FashionBoutigue
    {
        static void Main(string[] args)
        {
            int[] clothes = 
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int capacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothes);
            int racks = 1;
            int sum = stack.Pop();

            while (stack.Any())
            {
                sum += stack.Peek();

                if (sum < capacity)
                {
                    stack.Pop();
                }

                else if (sum == capacity)
                {
                    stack.Pop();
                    sum = 0;

                    if (stack.Any())
                    {
                        racks++;
                    }
                }

                else if (sum > capacity)
                {
                    sum = 0;
                    racks++;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
