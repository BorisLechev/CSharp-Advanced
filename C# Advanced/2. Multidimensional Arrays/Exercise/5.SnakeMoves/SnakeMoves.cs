using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] dimensions =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[dimensions[0], dimensions[1]];
            string snake = Console.ReadLine();
            Queue<char> queue = new Queue<char>(snake);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char needlessSymbol = queue.Dequeue();
                    matrix[row, col] = needlessSymbol;
                    queue.Enqueue(needlessSymbol);
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
