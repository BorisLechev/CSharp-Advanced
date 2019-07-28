using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            int[] input = 
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] array = 
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input[0]; i++)
            {
                stack.Push(array[i]);
            }

            for (int i = 0; i < input[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }

            else if (stack.Contains(input[2]))
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
