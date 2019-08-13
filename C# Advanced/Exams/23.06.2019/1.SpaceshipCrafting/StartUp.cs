using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.SpaceshipCrafting
{
    public class StartUp
    {
        static int glass;
        static int aluminium;
        static int lithium;
        static int carbonFiber;

        public static void Main()
        {
            int[] chemicalLiquids =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquidsQueue = new Queue<int>(chemicalLiquids);

            int[] physicalItems =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> itemsStack = new Stack<int>(physicalItems);

            while (liquidsQueue.Count > 0 && itemsStack.Count > 0)
            {
                int firstLiquid = liquidsQueue.Dequeue();
                int lastItem = itemsStack.Pop();
                int sum = firstLiquid + lastItem;
                bool isEqual = IsEqual(sum);

                if (!isEqual)
                {
                    lastItem += 3;
                    itemsStack.Push(lastItem);
                }
            }

            Output(liquidsQueue, itemsStack);
        }

        private static void Output(Queue<int> liquidsQueue, Stack<int> itemsStack)
        {
            if (glass > 0 && aluminium > 0 && lithium > 0 && carbonFiber > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }

            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquidsQueue.Count > 0)
            {
                Console.WriteLine($"Liquids left: {String.Join(", ", liquidsQueue)}");
            }

            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (itemsStack.Count > 0)
            {
                Console.WriteLine($"Physical items left: {String.Join(", ", itemsStack)}");
            }

            else
            {
                Console.WriteLine("Physical items left: none");
            }

            Console.WriteLine($"Aluminium: {aluminium}");
            Console.WriteLine($"Carbon fiber: {carbonFiber}");
            Console.WriteLine($"Glass: {glass}");
            Console.WriteLine($"Lithium: {lithium}");
        }

        private static bool IsEqual(int sum)
        {
            switch (sum)
            {
                case 25:
                    glass += 1;
                    return true;
                case 50:
                    aluminium += 1;
                    return true;
                case 75:
                    lithium += 1;
                    return true;
                case 100:
                    carbonFiber += 1;
                    return true;
                default:
                    return false;
            }
        }
    }
}
