using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ShoppingSpree
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                List<string> peopleInput = ParseInput();
                ParsePeople(people, peopleInput);

                List<string> productsInput = ParseInput();
                ParseProducts(products, productsInput);

                PrintMessage(people, products);
                PrintBoughtProductsByPerson(people, products);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintBoughtProductsByPerson(List<Person> people, List<Product> products)
        {
            people
                .ForEach(p => Console.WriteLine(p.ToString()));
        }

        private static void PrintMessage(List<Person> people, List<Product> products)
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string productName = tokens[1];

                Person person = people.FirstOrDefault(p => p.Name == name);
                Product product = products.FirstOrDefault(p => p.Name == productName);

                person.BuyProduct(person, product);
            }
        }

        private static void ParsePeople(List<Person> people, List<string> input)
        {
            foreach (string currentPerson in input)
            {
                string[] tokens = currentPerson
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                decimal money = decimal.Parse(tokens[1]);

                Person person = new Person(name, money);

                people.Add(person);
            }
        }

        private static void ParseProducts(List<Product> products, List<string> input)
        {
            foreach (string currentProduct in input)
            {
                string[] tokens = currentProduct
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                decimal cost = decimal.Parse(tokens[1]);

                Product product = new Product(name, cost);

                products.Add(product);
            }
        }

        private static List<string> ParseInput()
        {
            List<string> input = 
                Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            return input;
        }
    }
}
