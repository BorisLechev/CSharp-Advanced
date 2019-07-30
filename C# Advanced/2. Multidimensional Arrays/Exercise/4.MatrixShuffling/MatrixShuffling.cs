using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] dimensions =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] tokens =
                        Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = tokens[col];
                }
            }

            string commands = String.Empty;

            while ((commands = Console.ReadLine()) != "END")
            {
                string[] tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }

                else
                {
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (row1 < 0 || row1 > dimensions[0] - 1 || row2 < 0 || row2 > dimensions[0] - 1 
                        || col1 < 0 || col1 > dimensions[1] - 1 || col2 < 0 || col2 > dimensions[1] - 1)
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    else
                    {
                        string swap = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = swap;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write( matrix[row, col] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}