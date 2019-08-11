using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.TrajonInvasion
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            List<int> plates =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> warriesStack = new Stack<int>();
            Queue<int> platesQueue = new Queue<int>(plates);

            for (int i = 1; i <= number; i++)
            {
                List<int> warriors =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                AddWarries(warriesStack, warriors);

                if (i % 3 == 0)
                {
                    int plateToAdd = int.Parse(Console.ReadLine());
                    platesQueue.Enqueue(plateToAdd);
                }

                while (platesQueue.Count > 0 && warriesStack.Count > 0)
                {
                    int lastWarrior = warriesStack.Pop();
                    int firstPlate = platesQueue.Dequeue();

                    if (lastWarrior < firstPlate)
                    {
                        firstPlate -= lastWarrior;

                        List<int> queueToList = platesQueue.ToList();
                        queueToList.Insert(0, firstPlate);

                        platesQueue = new Queue<int>(queueToList);
                    }

                    else if (lastWarrior > firstPlate)
                    {
                        lastWarrior -= firstPlate;
                        warriesStack.Push(lastWarrior);
                    }
                }

                if (platesQueue.Count == 0)
                {
                    break;
                }
            }

            if (warriesStack.Count == 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {String.Join(", ", platesQueue)}");
            }

            else if (platesQueue.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {String.Join(", ", warriesStack)}");
            }
        }

        private static void AddWarries(Stack<int> warriesStack, List<int> warriors)
        {
            foreach (int warrior in warriors)
            {
                warriesStack.Push(warrior);
            }
        }
    }
}
