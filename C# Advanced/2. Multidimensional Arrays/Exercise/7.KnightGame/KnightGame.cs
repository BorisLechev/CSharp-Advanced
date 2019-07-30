using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] tokens = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = tokens[col];
                }
            }

            int counter = 0;

            while (true)
            {
                int maxCount = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int currentCount = 0;

                        if (matrix[row, col] == 'K')
                        {
                            /* x x
                               x
                               K
                               row - 2 && col + 1*/
                            if (IsInside(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            /* x x
                                 x
                                 K
                              row - 2 && col - 1*/
                            if (IsInside(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            /*   K
                                 x
                                 x x */
                            if (IsInside(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            /*   K
                                 x
                               x x */
                            if (IsInside(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            /* K x x
                                   x */
                            if (IsInside(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }

                            /*    x
                              K x x */
                            if (IsInside(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }

                            /* x x K
                               x    */
                            if (IsInside(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            /* x   
                               x x K */
                            if (IsInside(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }

                matrix[knightRow, knightCol] = '0';
                counter++;
            }

            Console.WriteLine(counter);
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
