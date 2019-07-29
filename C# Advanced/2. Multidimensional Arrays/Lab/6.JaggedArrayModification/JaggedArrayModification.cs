using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] input =
                    Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = input;
            }

            string commands = String.Empty;

            while ((commands = Console.ReadLine()) != "END")
            {
                string[] tokens = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                int commandRow = int.Parse(tokens[1]);
                int commandCol = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (commandRow < 0 
                    || commandRow >= rows
                    || commandCol < 0 
                    || commandCol >= jaggedArray[commandRow].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[commandRow][commandCol] += value;
                }

                else if (command == "Subtract")
                {
                    jaggedArray[commandRow][commandCol] -= value;
                }
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}