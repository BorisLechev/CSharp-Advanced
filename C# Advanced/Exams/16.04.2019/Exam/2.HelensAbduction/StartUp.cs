using System;

namespace _2.HelensAbduction
{
    public class StartUp
    {
        static char[][] battleField;

        static byte parisRow;
        static byte parisCol;

        public static void Main()
        {
            int parissEnergy = int.Parse(Console.ReadLine());
            byte fieldSize = byte.Parse(Console.ReadLine());
            bool isWon = false;

            battleField = new char[fieldSize][];

            Initialize();
            FindParisCoordinates();

            while (parissEnergy > 0)
            {
                string[] moveCommands =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string moveCommand = moveCommands[0];
                byte commandRow = byte.Parse(moveCommands[1]);
                byte commandCol = byte.Parse(moveCommands[2]);

                battleField[parisRow][parisCol] = '-';
                battleField[commandRow][commandCol] = 'S';

                MoveDirections(moveCommand);
                parissEnergy--;

                if (battleField[parisRow][parisCol] == 'S')
                {
                    parissEnergy -= 2;
                    battleField[parisRow][parisCol] = 'P';
                }

                else if (battleField[parisRow][parisCol] == 'H')
                {
                    battleField[parisRow][parisCol] = '-';
                    isWon = true;
                    break;
                }

                else if (battleField[parisRow][parisCol] == '-')
                {
                    battleField[parisRow][parisCol] = 'P';
                }

                if (parissEnergy <= 0)
                {
                    battleField[parisRow][parisCol] = 'X';
                    break;
                }
            }

            PrintOutput(parissEnergy, isWon);
        }

        private static void FindParisCoordinates()
        {
            bool isFound = false;
            for (byte row = 0; row < battleField.Length; row++)
            {
                for (byte col = 0; col < battleField[row].Length; col++)
                {
                    if (battleField[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;

                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }
        }

        private static void PrintOutput(int parissEnergy, bool isWon)
        {
            if (isWon)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parissEnergy}");
            }

            else
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            for (int row = 0; row < battleField.Length; row++)
            {
                Console.WriteLine(String.Join("", battleField[row]));
            }
        }

        private static void MoveDirections(string moveCommand)
        {
            if (moveCommand == "up")
            {
                if (parisRow - 1 >= 0)
                {
                    parisRow--;
                }
            }

            else if (moveCommand == "down")
            {
                if (parisRow + 1 < battleField.Length)
                {
                    parisRow++;
                }
            }

            else if (moveCommand == "left")
            {
                if (parisCol - 1 >= 0)
                {
                    parisCol--;
                }
            }

            else if (moveCommand == "right")
            {
                if (parisCol + 1 < battleField[parisRow].Length)
                {
                    parisCol++;
                }
            }
        }

        private static void Initialize()
        {
            for (int i = 0; i < battleField.Length; i++)
            {
                battleField[i] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
