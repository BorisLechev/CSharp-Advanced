using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(String.Join(" ", numbers));
                    continue;
                }

                var commandParser = CommandParser(command);

                numbers = numbers.Select(commandParser).ToArray();
            }
        }

        private static Func<int, int> CommandParser(string command)
        {
            switch (command)
            {
                case "add":
                    return n => n += 1;
                case "multiply":
                    return n => n *= 2;
                case "subtract":
                    return n => n -= 1;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}