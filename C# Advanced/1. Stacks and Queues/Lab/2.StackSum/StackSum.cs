using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            int[] input =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input);
            string commandInput = Console.ReadLine().ToLower();

            while (commandInput != "end")
            {
                string[] tokens = commandInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0].ToLower();

                if (command == "add")
                {
                    stack.Push(int.Parse(tokens[1]));
                    stack.Push(int.Parse(tokens[2]));
                }

                else if (command == "remove")
                {
                    int numbersToRemove = int.Parse(tokens[1]);

                    if (numbersToRemove <= stack.Count)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                commandInput = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}