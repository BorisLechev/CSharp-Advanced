using System;
using System.Linq;

namespace _2.TronRacers
{
    public class StartUp
    {
        static char[,] battleField;

        static int firstPlayerRow;
        static int firstPlayerCol;

        static int secondPlayerRow;
        static int secondPlayerCol;

        public static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            battleField = new char[sizeOfMatrix, sizeOfMatrix];

            Initialize();

            while (true)
            {
                string[] directions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (directions[0] == "down")
                {
                    firstPlayerRow++;

                    if (firstPlayerRow > battleField.GetLength(0) - 1)
                    {
                        firstPlayerRow = 0;
                    }
                }

                else if (directions[0] == "up")
                {
                    firstPlayerRow--;

                    if (firstPlayerRow < 0)
                    {
                        firstPlayerRow = battleField.GetLength(0) - 1;
                    }
                }

                else if (directions[0] == "left")
                {
                    firstPlayerCol--;

                    if (firstPlayerCol < 0)
                    {
                        firstPlayerCol = battleField.GetLength(1) - 1;
                    }
                }

                else if (directions[0] == "right")
                {
                    firstPlayerCol++;

                    if (firstPlayerCol > battleField.GetLength(1) - 1)
                    {
                        firstPlayerCol = 0;
                    }
                }

                if (battleField[firstPlayerRow, firstPlayerCol] == 's')
                {
                    battleField[firstPlayerRow, firstPlayerCol] = 'x';
                    End();
                }

                else
                {
                    battleField[firstPlayerRow, firstPlayerCol] = 'f';
                }


                if (directions[1] == "down")
                {
                    secondPlayerRow++;

                    if (secondPlayerRow > battleField.GetLength(0) - 1)
                    {
                        secondPlayerRow = 0;
                    }
                }

                else if (directions[1] == "up")
                {
                    secondPlayerRow--;

                    if (secondPlayerRow < 0)
                    {
                        secondPlayerRow = battleField.GetLength(0) - 1;
                    }
                }

                else if (directions[1] == "left")
                {
                    secondPlayerCol--;

                    if (secondPlayerCol < 0)
                    {
                        secondPlayerCol = battleField.GetLength(1) - 1;
                    }
                }

                else if (directions[1] == "right")
                {
                    secondPlayerCol++;

                    if (secondPlayerCol > battleField.GetLength(1) - 1)
                    {
                        secondPlayerCol = 0;
                    }
                }

                if (battleField[secondPlayerRow, secondPlayerCol] == 'f')
                {
                    battleField[secondPlayerRow, secondPlayerCol] = 'x';
                    End();
                }

                else
                {
                    battleField[secondPlayerRow, secondPlayerCol] = 's';
                }
            }
        }

        private static void End()
        {
            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                for (int col = 0; col < battleField.GetLength(1); col++)
                {
                    Console.Write(battleField[row, col]);
                }

                Console.WriteLine();
            }

            Environment.Exit(0);
        }

        private static void Initialize()
        {
            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                char[] tokens =
                   Console.ReadLine()
                   .ToCharArray();

                for (int col = 0; col < battleField.GetLength(1); col++)
                {
                    battleField[row, col] = tokens[col];

                    if (battleField[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }

                    else if (battleField[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }
        }
    }
}
