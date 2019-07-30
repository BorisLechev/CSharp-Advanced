using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.BombTheBasement
{
    class BombTheBasement
    {
        static void Main(string[] args)
        {
            int[] dimensions =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bombParameters =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetRow = bombParameters[0];
            int targetCol = bombParameters[1];
            int radius = bombParameters[2];
            int[][] jaggedArray = new int[dimensions[0]][];

            for (int row = 0; row < dimensions[0]; row++)
            {
                jaggedArray[row] = new int[dimensions[1]];
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++) // защото може всеки ред да има различен брой колони
                {
                    bool isInRadius = Math.Pow(row - targetRow, 2) + Math.Pow(col - targetCol, 2)
                        <= Math.Pow(radius, 2);

                    if (isInRadius)
                    {
                        jaggedArray[row][col] = 1;
                    }
                }
            }

            // Итерирам по колони и [0] тъй като всички редове имат еднакъв на брой колони така че може и [1],[2],[3] и т.н.

            for (int col = 0; col < jaggedArray[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < jaggedArray.Length; row++)
                {
                    if (jaggedArray[row][col] == 1)
                    {
                        counter++;
                        jaggedArray[row][col] = 0;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    jaggedArray[row][col] = 1;
                }
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}