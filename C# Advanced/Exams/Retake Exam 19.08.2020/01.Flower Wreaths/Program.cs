using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var lilies = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var roses = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            var liliesStack = new Stack<int>(lilies);
            var rosesQueue = new Queue<int>(roses);

            int wreath = 0;
            int storedFlowers = 0;

            while (liliesStack.Any() && rosesQueue.Any())
            {
                var currentLily = liliesStack.Peek();
                var currentRose = rosesQueue.Peek();

                var sum = currentLily + currentRose;

                if (sum == 15)
                {
                    liliesStack.Pop();
                    rosesQueue.Dequeue();

                    wreath += 1;
                }
                else if (sum > 15)
                {
                    liliesStack.Push(liliesStack.Pop() - 2);
                }
                else
                {
                    storedFlowers += liliesStack.Pop() + rosesQueue.Dequeue();
                }
            }

            int potentialWreaths = storedFlowers / 15;

            wreath += potentialWreaths;

            if (wreath >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreath} wreaths more!");
            }
        }
    }
}
