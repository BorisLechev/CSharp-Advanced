using System;
using System.Linq;

namespace _4.GenericSwapMethodIntegers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int numberOfBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBoxes; i++)
            {
                int input = int.Parse(Console.ReadLine());

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
