using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int mainDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < size; row++)
            {
                int[] tokens =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = tokens[col];
                }

                mainDiagonalSum += matrix[row, row];
                secondaryDiagonalSum += matrix[row, size - row - 1];
            }

            Console.WriteLine(Math.Abs(mainDiagonalSum - secondaryDiagonalSum));
        }
    }
}
