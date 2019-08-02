using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int countOfIntegers = int.Parse(Console.ReadLine());
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            
            for (int i = 0; i < countOfIntegers; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(input))
                {
                    dictionary.Add(input, 0);
                }

                dictionary[input]++;
            }

            foreach (var item in dictionary)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
