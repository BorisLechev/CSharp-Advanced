using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.SortPersonsByNameAndAge
{
    public class StartUp
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = commandTokens[0];
                string lastName = commandTokens[1];
                int age = int.Parse(commandTokens[2]);

                Person person = new Person(firstName, lastName, age);

                people.Add(person);
            }

            people
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
