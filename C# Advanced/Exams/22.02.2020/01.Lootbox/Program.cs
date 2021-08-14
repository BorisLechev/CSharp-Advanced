using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLootBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var secondLootBox = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var firstBoxQueue = new Queue<int>(firstLootBox);
            var secondBoxStack = new Stack<int>(secondLootBox);

            int sumOfClaimedItems = 0;

            while (firstBoxQueue.Any() && secondBoxStack.Any())
            {
                var firstBoxItem = firstBoxQueue.Peek();
                var secondBoxItem = secondBoxStack.Pop();

                var sum = firstBoxItem + secondBoxItem;

                if (sum % 2 == 0)
                {
                    sumOfClaimedItems += sum;

                    firstBoxQueue.Dequeue();
                }
                else
                {
                    firstBoxQueue.Enqueue(secondBoxItem);
                }
            }

            if (firstBoxQueue.Any() == false)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBoxStack.Any() == false)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumOfClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfClaimedItems}");
            }
        }
    }
}
