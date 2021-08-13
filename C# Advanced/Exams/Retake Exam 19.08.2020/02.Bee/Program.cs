using System;

namespace _02.Bee
{
    class Program
    {
        //static int currentBeeRow;
        //static int currentBeeCol;

        static void Main(string[] args)
        {
            var dimensions = int.Parse(Console.ReadLine());

            var matrix = new char[dimensions, dimensions];
            bool isOut = false;
            int pollinatedFlowersCount = 0;

            int currentBeeRow = 0;
            int currentBeeCol = 0;
            int prevBeeRow = 0;
            int prevBeeCol = 0;

            InitializeMatrix(matrix, ref currentBeeRow, ref currentBeeCol);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                KeepingPreviousPositions(currentBeeRow, currentBeeCol, ref prevBeeRow, ref prevBeeCol);
                MovingTheBee(ref currentBeeRow, ref currentBeeCol, command);

                isOut = ValidateBeePosition(matrix, currentBeeRow, currentBeeCol, isOut);

                matrix[prevBeeRow, prevBeeCol] = '.';

                if (isOut)
                {
                    Console.WriteLine("The bee got lost!");

                    break;
                }

                if (matrix[currentBeeRow, currentBeeCol] == 'f')
                {
                    pollinatedFlowersCount++;
                    matrix[currentBeeRow, currentBeeCol] = 'B';
                }
                else if (matrix[currentBeeRow, currentBeeCol] == 'O')
                {
                    KeepingPreviousPositions(currentBeeRow, currentBeeCol, ref prevBeeRow, ref prevBeeCol);
                    MovingTheBee(ref currentBeeRow, ref currentBeeCol, command);

                    isOut = ValidateBeePosition(matrix, currentBeeRow, currentBeeCol, isOut);
                    matrix[prevBeeRow, prevBeeCol] = '.';

                    if (isOut)
                    {
                        Console.WriteLine("The bee got lost!");

                        break;
                    }

                    if (matrix[currentBeeRow, currentBeeCol] == 'f')
                    {
                        pollinatedFlowersCount++;
                    }

                    matrix[currentBeeRow, currentBeeCol] = 'B';
                }
                else
                {
                    matrix[prevBeeRow, prevBeeCol] = '.';
                    matrix[currentBeeRow, currentBeeCol] = 'B';
                }
            }

            if (pollinatedFlowersCount >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowersCount} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowersCount} flowers more");
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

        private static void MovingTheBee(ref int currentBeeRow, ref int currentBeeCol, string command)
        {
            switch (command)
            {
                case "up":
                    currentBeeRow--;
                    break;
                case "down":
                    currentBeeRow++;
                    break;
                case "left":
                    currentBeeCol--;
                    break;
                case "right":
                    currentBeeCol++;
                    break;
            }
        }

        private static void KeepingPreviousPositions(int currentBeeRow, int currentBeeCol, ref int prevBeeRow, ref int prevBeeCol)
        {
            prevBeeRow = currentBeeRow;
            prevBeeCol = currentBeeCol;
        }

        private static bool ValidateBeePosition(char[,] matrix, int currentBeeRow, int currentBeeCol, bool isOut)
        {
            if (currentBeeRow < 0 || currentBeeRow >= matrix.GetLength(0) || currentBeeCol < 0 || currentBeeCol >= matrix.GetLength(1))
            {
                isOut = true;
            }

            return isOut;
        }

        private static void InitializeMatrix(char[,] matrix, ref int currentBeeRow, ref int currentBeeCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'B')
                    {
                        currentBeeRow = row;
                        currentBeeCol = col;
                    }
                }
            }
        }
    }
}
