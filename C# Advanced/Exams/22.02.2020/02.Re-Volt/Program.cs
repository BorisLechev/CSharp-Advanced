using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            var playerRow = 0;
            var playerCol = 0;
            bool isWon = false;

            InitializeMatrix(matrix, ref playerRow, ref playerCol);

            while (isWon == false && numberOfCommands > 0)
            {
                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';
                numberOfCommands--;

                NextPosition(ref playerRow, ref playerCol, command);
                ValidatePlayerPosition(matrix, ref playerRow, ref playerCol);

                if (matrix[playerRow, playerCol] == 'F')
                {
                    isWon = true;
                    matrix[playerRow, playerCol] = 'f';

                    break;
                }
                else if (matrix[playerRow, playerCol] == 'T')
                {
                    PreviousPosition(ref playerRow, ref playerCol, command);
                }
                else if (matrix[playerRow, playerCol] == 'B')
                {
                    NextPosition(ref playerRow, ref playerCol, command);
                }

                ValidatePlayerPosition(matrix, ref playerRow, ref playerCol);

                matrix[playerRow, playerCol] = 'f';
            }

            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

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

        private static void PreviousPosition(ref int playerRow, ref int playerCol, string command)
        {
            switch (command)
            {
                case "up":
                    playerRow++;
                    break;
                case "down":
                    playerRow--;
                    break;
                case "left":
                    playerCol++;
                    break;
                case "right":
                    playerCol--;
                    break;
                default:
                    break;
            }
        }

        private static void ValidatePlayerPosition(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerRow < 0)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            if (playerRow >= matrix.GetLength(0))
            {
                playerRow = 0;
            }
            if (playerCol < 0)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            if (playerCol >= matrix.GetLength(1))
            {
                playerCol = 0;
            }
        }

        private static void NextPosition(ref int playerRow, ref int playerCol, string command)
        {
            switch (command)
            {
                case "up":
                    playerRow--;
                    break;
                case "down":
                    playerRow++;
                    break;
                case "left":
                    playerCol--;
                    break;
                case "right":
                    playerCol++;
                    break;
                default:
                    break;
            }
        }

        private static void InitializeMatrix(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
