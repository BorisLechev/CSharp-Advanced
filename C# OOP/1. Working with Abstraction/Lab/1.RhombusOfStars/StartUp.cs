using System;

namespace _1.RhombusOfStars
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                PrintRow(number, i);
            }

            for (int i = number - 1; i >= 1; i--)
            {
                PrintRow(number, i);
            }
        }

        private static void PrintRow(int size, int starCount)
        {
            for (int i = 0; i < size - starCount; i++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < starCount; col++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
