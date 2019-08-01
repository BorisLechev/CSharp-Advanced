using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            SortedDictionary<string, Dictionary<string, double>> dictionary =
                new SortedDictionary<string, Dictionary<string, double>>();

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (!dictionary.ContainsKey(tokens[0]))
                {
                    dictionary.Add(tokens[0], new Dictionary<string, double>());
                }

                dictionary[tokens[0]].Add(tokens[1], double.Parse(tokens[2]));
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                } 
            }
        }
    }
}
