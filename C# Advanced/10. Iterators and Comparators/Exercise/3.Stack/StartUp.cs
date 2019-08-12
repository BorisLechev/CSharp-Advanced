using System;
using System.Linq;

namespace _3.Stack
{
    public class StartUp
    {
        public static void Main()
        {
            Stack<string> stack = new Stack<string>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                switch (command)
                {
                    case "Push":
                        stack.Push(commands.Skip(1).ToList());
                        break;
                    case "Pop":
                        if (stack.Count() == 0)
                        {
                            Console.WriteLine("No elements");
                        }

                        else
                        {
                            stack.Pop();
                        }
                        break;
                    default:
                        break;
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine(stack);
                Console.WriteLine(stack);
            }
        }
    }
}
