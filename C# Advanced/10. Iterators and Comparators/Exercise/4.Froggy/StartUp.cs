using System;
using System.Linq;

namespace _4.Froggy
{
    public class StartUp
    {
        public static void Main()
        {
            int[] stones =
                Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(stones);

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
