using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static int[,] matrix;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            matrix = new int[dimensions[0], dimensions[1]];

            InitializeMatrix();

            string input = "";

            var coordinatesList = new List<Coordinate>();

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                var coordinates = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var row = coordinates[0];
                var col = coordinates[1];

                if (row > matrix.GetLength(0) - 1 || row < 0 || col > matrix.GetLength(1) - 1 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                coordinatesList.Add(new Coordinate(row, col));

                // za da ostane 1, a ne pri polvane na stoinosti v lyavo/dyasno/dolu/gore da se uvelichava i da stane 4
                matrix[row, col] = -3;
            }

            foreach (var coordinate in coordinatesList)
            {
                int currentRow = coordinate.Row;
                int currentCol = coordinate.Col;

                BloomFlowers(currentRow, currentCol, "up");
                BloomFlowers(currentRow, currentCol, "down");
                BloomFlowers(currentRow, currentCol, "left");
                BloomFlowers(currentRow, currentCol, "right");
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void BloomFlowers(int currentRow, int currentCol, string direction)
        {
            while (currentRow >= 0 && currentRow < matrix.GetLength(0) &&
                                currentCol >= 0 && currentCol < matrix.GetLength(1))
            {
                matrix[currentRow, currentCol] += 1;

                switch (direction)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void InitializeMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }
        }
    }

    class Coordinate
    {
        public Coordinate(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
