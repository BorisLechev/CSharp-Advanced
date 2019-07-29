﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.SumMatrixElements
{
    class SumMatrixElements
    {
        static void Main(string[] args)
        {
            int[] sizes =
                 Console.ReadLine()
                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] tokens =
                    Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = tokens[col];
                    sum += tokens[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}