using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int firstOperand = int.Parse(stack.Pop());
                string oper = stack.Pop();
                int secondOperand = int.Parse(stack.Pop());

                switch (oper)
                {
                    case "+":
                        stack.Push($"{firstOperand + secondOperand}");
                        break;
                    case "-":
                        stack.Push($"{firstOperand - secondOperand}");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}