using System;
using System.Collections.Generic;
using System.Linq;

public class Program   // Не е довършена
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        try
        {
            ParsePeople(people);
            ParseProducts(products);
            PrintMessage(people, products);
        }
        catch (Exception)
        {

            throw;
        }
        var productInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();


    }

    private static void PrintMessage(List<Person> people, List<Product> products)
    {
        string input = string.Empty;

        while ((input=Console.ReadLine())!= "END")
        {
            var splittedInput = input.Split(" ");

            string personInput = splittedInput[0];
            string productInput = splittedInput[1];

            Person person = people.First(x => x.Name == personInput);
            Product product = products.First(x => x.Name == productInput);

            if (person.Money>=product.Cost)
            {
                this.Money -= product.Cost;
                person.
            }
        }
    }

    private static void ParseProducts(List<Product> products)
    {
        var productInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        foreach (var currentProduct in productInput)
        {
            var splittedData = currentProduct.Split("=");

            Product product = new Product(splittedData[0], decimal.Parse(splittedData[1]));

            products.Add(product);
        }
    }

    private static void ParsePeople(List<Person> people)
    {
        var peopleInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        foreach (var currentPerson in peopleInput)
        {
            var splittedData = currentPerson.Split("=");

            Person person = new Person(splittedData[0], decimal.Parse(splittedData[1]));

            people.Add(person);
        }
    }
}