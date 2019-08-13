using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SpaceStationEstablishment
{
    public class StartUp
    {
        static int stephensRow;
        static int stephensCol;
        static int blackHoleRow1;
        static int blackHoleCol1;
        static int blackHoleRow2;
        static int blackHoleCol2;

        static char[,] matrix;
        static bool isOut;

        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int stephensEnergy = 0;

            matrix = new char[matrixSize, matrixSize];

            Initialize();

            while (!isOut && stephensEnergy < 50)
            {
                string moveCommand = Console.ReadLine();

                matrix[stephensRow, stephensCol] = '-';

                MoveDirections(moveCommand);

                if (Int32.TryParse(matrix[stephensRow, stephensCol].ToString(), out int star))
                {
                    stephensEnergy += int.Parse(matrix[stephensRow, stephensCol].ToString());
                    matrix[stephensRow, stephensCol] = '-';
                }

                else if (stephensRow == blackHoleRow1 && stephensCol == blackHoleCol1)
                {
                    stephensRow = blackHoleRow2;
                    stephensCol = blackHoleCol2;
                    matrix[blackHoleRow1, blackHoleCol1] = '-';
                    matrix[blackHoleRow2, blackHoleCol2] = 'S';
                }

                else if (stephensRow == blackHoleRow2 && stephensCol == blackHoleCol2)
                {
                    stephensRow = blackHoleRow1;
                    stephensCol = blackHoleCol1;
                    matrix[blackHoleRow2, blackHoleCol2] = '-';
                    matrix[blackHoleRow1, blackHoleCol1] = 'S';
                }
            }

            if (isOut || stephensEnergy < 50)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                Console.WriteLine($"Star power collected: {stephensEnergy}");
                matrix[stephensRow, stephensCol] = '-';
            }

            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                Console.WriteLine($"Star power collected: {stephensEnergy}");
            }

            Outputter();
        }

        private static void Outputter()
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

        private static void MoveDirections(string moveCommand)
        {
            if (moveCommand == "up")
            {
                if (stephensRow - 1 >= 0)
                {
                    stephensRow--;
                }

                else
                {
                    isOut = true;
                }
            }

            else if (moveCommand == "down")
            {
                if (stephensRow + 1 <= matrix.GetLength(0) - 1)
                {
                    stephensRow++;
                }

                else
                {
                    isOut = true;
                }
            }

            else if (moveCommand == "left")
            {
                if (stephensCol - 1 >= 0)
                {
                    stephensCol--;
                }

                else
                {
                    isOut = true;
                }
            }

            else if (moveCommand == "right")
            {
                if (stephensCol + 1 <= matrix.GetLength(1) - 1)
                {
                    stephensCol++;
                }

                else
                {
                    isOut = true;
                }
            }
        }

        private static void Initialize()
        {
            List<int> holes = new List<int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] tokens =
                   Console.ReadLine()
                   .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = tokens[col];

                    if (matrix[row, col] == 'S')
                    {
                        stephensRow = row;
                        stephensCol = col;
                    }

                    else if (matrix[row, col] == 'O')
                    {
                        holes.Add(row);
                        holes.Add(col);
                    }
                }
            }

            if (holes.Count > 0)
            {
                blackHoleRow1 = holes[0];
                blackHoleCol1 = holes[1];
                blackHoleRow2 = holes[2];
                blackHoleCol2 = holes[3];
            }
        }
    }
}
