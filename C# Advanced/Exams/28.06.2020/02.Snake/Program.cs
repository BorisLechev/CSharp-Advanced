using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];
            var currentSnakeRow = 0;
            var currentSnakeCol = 0;
            bool isOut = currentSnakeRow < 0 || currentSnakeCol >= matrix.GetLength(0) ||
                currentSnakeCol < 0 || currentSnakeCol >= matrix.GetLength(1);
            var foodQuantity = 0;

            InitializeMatrix(matrix, ref currentSnakeRow, ref currentSnakeCol);

            while (foodQuantity < 10)
            {
                string command = Console.ReadLine();

                matrix[currentSnakeRow, currentSnakeCol] = '.';

                switch (command)
                {
                    case "up":
                        currentSnakeRow--;
                        break;
                    case "down":
                        currentSnakeRow++;
                        break;
                    case "left":
                        currentSnakeCol--;
                        break;
                    case "right":
                        currentSnakeCol++;
                        break;
                    default:
                        break;
                }

                if (isOut)
                {
                    break;
                }

                if (matrix[currentSnakeRow, currentSnakeCol] == '*')
                {
                    foodQuantity++;
                }
                else if (matrix[currentSnakeRow, currentSnakeCol] == 'B')
                {
                    matrix[currentSnakeRow, currentSnakeCol] = '.';

                    var burrowRow = 0;
                    var burrowCol = 0;

                    FindSecondBurrow(matrix, currentSnakeRow, currentSnakeCol, ref burrowRow, ref burrowCol);

                    currentSnakeRow = burrowRow;
                    currentSnakeCol = burrowCol;
                }

                matrix[currentSnakeRow, currentSnakeCol] = 'S';
            }

            if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FindSecondBurrow(char[,] matrix, int currentSnakeRow, int currentSnakeCol, ref int burrowRow, ref int burrowCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        burrowRow = row;
                        burrowCol = col;
                    }
                }
            }
        }

        private static void InitializeMatrix(char[,] matrix, ref int currentSnakeRow, ref int currentSnakeCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        currentSnakeRow = row;
                        currentSnakeCol = col;
                    }
                }
            }
        }
    }
}
