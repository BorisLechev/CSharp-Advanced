using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Potato
    {
        public static void Main()
        {
            long capacityOfTheBag = long.Parse(Console.ReadLine());
            string[] quantityPairs = 
                Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Bag bag = new Bag(capacityOfTheBag);

            for (int i = 0; i < quantityPairs.Length; i += 2)
            {
                string name = quantityPairs[i];
                long amount = long.Parse(quantityPairs[i + 1]);

                string typeOfItem = GetType(name);

                bool skipTheItem = bag.ItemsMustBeSkipped(typeOfItem, capacityOfTheBag, amount);

                if (skipTheItem)
                {
                    continue;
                }

                bag.AddItem(typeOfItem, amount, name);
            }

            Console.WriteLine(bag);
        }

        private static string GetType(string name)
        {
            string typeOfItem = string.Empty;

            if (name.Length == 3)
            {
                typeOfItem = "Cash";
            }

            else if (name.ToLower().EndsWith("gem"))
            {
                typeOfItem = "Gem";
            }

            else if (name.ToLower() == "gold")
            {
                typeOfItem = "Gold";
            }

            return typeOfItem;
        }
    }
}