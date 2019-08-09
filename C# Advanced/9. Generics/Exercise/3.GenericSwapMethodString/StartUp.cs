using System;
using System.Linq;

namespace _3.GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int numberOfBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBoxes; i++)
            {
                string input = Console.ReadLine();

                box.Add(input);
            }

            int[] indexes =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.SwapElements(indexes[0], indexes[1]);

            Console.WriteLine(box.ToString());
        }
    }
}
