using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._1.TrojanInvasion
{
    public class StartUp
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
                    plates.Add(plateToAdd);
                }

                while (plates.Count > 0 && warriesStack.Count > 0)
                {
                    int lastWarrior = warriesStack.Pop();
                    int firstPlate = plates[0];

                    if (lastWarrior < firstPlate)
                    {
                        firstPlate -= lastWarrior;

                        plates[0] = firstPlate;
                    }

                    else if (lastWarrior > firstPlate)
                    {
                        lastWarrior -= firstPlate;
                        warriesStack.Push(lastWarrior);
                        plates.RemoveAt(0);
                    }

                    else
                    {
                        plates.RemoveAt(0);
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {String.Join(", ", warriesStack)}");
            }

            else if (warriesStack.Count == 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {String.Join(", ", plates)}");
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
