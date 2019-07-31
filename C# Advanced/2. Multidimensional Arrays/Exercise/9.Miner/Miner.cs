using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Miner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            string[] commands =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int minerRow = -1;
            int minerColumn = -1;
            int coalCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] tokens =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = tokens[col];

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerColumn = col;
                        matrix[row, col] = '*';
                    }

                    else if (matrix[row, col] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "up":
                        if (minerRow - 1 >= 0)
                        {
                            minerRow -= 1;
                        }
                        break;
                    case "down":
                        if (minerRow + 1 < size)
                        {
                            minerRow += 1;
                        }
                        break;
                    case "left":
                        if (minerColumn - 1 >= 0)
                        {
                            minerColumn -= 1;
                        }
                        break;
                    case "right":
                        if (minerColumn + 1 < size)
                        {
                            minerColumn += 1;
                        }
                        break;
                    default:
                        break;
                }

                switch (matrix[minerRow, minerColumn])
                {
                    case 'e':
                        Console.WriteLine($"Game over! ({minerRow}, {minerColumn})");
                        return;
                    case 'c':
                        coalCount--;
                        matrix[minerRow, minerColumn] = '*';

                        if (coalCount == 0)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerColumn})");
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({minerRow}, {minerColumn})");
        }
    }
}