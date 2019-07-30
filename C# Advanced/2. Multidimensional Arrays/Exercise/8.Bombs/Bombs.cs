using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

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

            int[] coordinates =
                Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < coordinates.Length; i+=2)
            {
                int rowBomb = coordinates[i];
                int colBomb = coordinates[i + 1];
                int power;

                if (IsValid(matrix, rowBomb, colBomb))
                {
                    if (matrix[rowBomb, colBomb] > 0)
                    {
                        power = matrix[rowBomb, colBomb];
                        matrix[rowBomb, colBomb] = 0;

                        if (IsValid(matrix, rowBomb - 1, colBomb) && matrix[rowBomb - 1, colBomb] > 0)
                        {
                            matrix[rowBomb - 1, colBomb] -= power;
                        }

                        if (IsValid(matrix, rowBomb - 1, colBomb + 1) && matrix[rowBomb - 1, colBomb + 1] > 0)
                        {
                            matrix[rowBomb - 1, colBomb + 1] -= power;
                        }

                        if (IsValid(matrix, rowBomb - 1, colBomb - 1) && matrix[rowBomb - 1, colBomb - 1] > 0)
                        {
                            matrix[rowBomb - 1, colBomb - 1] -= power;
                        }

                        if (IsValid(matrix, rowBomb, colBomb - 1) && matrix[rowBomb, colBomb - 1] > 0)
                        {
                            matrix[rowBomb, colBomb - 1] -= power;
                        }

                        if (IsValid(matrix, rowBomb, colBomb + 1) && matrix[rowBomb, colBomb + 1] > 0)
                        {
                            matrix[rowBomb, colBomb + 1] -= power;
                        }

                        if (IsValid(matrix, rowBomb + 1, colBomb - 1) && matrix[rowBomb + 1, colBomb - 1] > 0)
                        {
                            matrix[rowBomb + 1, colBomb - 1] -= power;
                        }

                        if (IsValid(matrix, rowBomb + 1, colBomb) && matrix[rowBomb + 1, colBomb] > 0)
                        {
                            matrix[rowBomb + 1, colBomb] -= power;
                        }

                        if (IsValid(matrix, rowBomb + 1, colBomb + 1) && matrix[rowBomb + 1, colBomb + 1] > 0)
                        {
                            matrix[rowBomb + 1, colBomb + 1] -= power;
                        }
                    }
                }
            }

            int alliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        alliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {alliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValid(int[,] matrix, int rowBomb, int colBomb)
        {
            return rowBomb >= 0 && rowBomb < matrix.GetLength(0) && colBomb >= 0 && colBomb < matrix.GetLength(1);
        }
    }
}