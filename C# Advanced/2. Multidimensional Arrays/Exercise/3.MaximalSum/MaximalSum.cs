using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] dimensions =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] tokens =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = tokens[col];
                }
            }

            int maxSum = int.MinValue;
            int selectedRow = -1;
            int selectedCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + 
                            matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                            matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        selectedRow = row;
                        selectedCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}" +
                $"{Environment.NewLine}" +
                $"{matrix[selectedRow, selectedCol]} {matrix[selectedRow, selectedCol + 1]}" +
                $" {matrix[selectedRow, selectedCol + 2]}" +
                $"{Environment.NewLine}" +
                $"{matrix[selectedRow + 1, selectedCol]} {matrix[selectedRow + 1, selectedCol + 1]}" +
                $" {matrix[selectedRow + 1, selectedCol + 2]}" +
                $"{Environment.NewLine}" +
                $"{matrix[selectedRow + 2, selectedCol]} {matrix[selectedRow + 2, selectedCol + 1]}" +
                $" {matrix[selectedRow + 2, selectedCol + 2]}");
        }
    }
}