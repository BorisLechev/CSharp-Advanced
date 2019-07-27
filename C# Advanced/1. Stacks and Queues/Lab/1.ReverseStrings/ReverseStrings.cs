using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            while (stack.Count() != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}