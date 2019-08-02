using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!dictionary.ContainsKey(input[0]))
                {
                    dictionary.Add(input[0], new Dictionary<string, int>());
                }

                foreach (string cloth in clothes)
                {
                    if (!dictionary[input[0]].ContainsKey(cloth))
                    {
                        dictionary[input[0]].Add(cloth, 0);
                    }

                    dictionary[input[0]][cloth]++;
                }
            }

            string[] clothToSearch = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in dictionary)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (clothToSearch[0] == color.Key && clothToSearch[1] == cloth.Key)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
