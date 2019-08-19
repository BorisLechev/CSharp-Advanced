using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                int numberOfLines = int.Parse(Console.ReadLine());
                List<Person> people = new List<Person>();

                for (int i = 0; i < numberOfLines; i++)
                {
                    string[] commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string firstName = commandTokens[0];
                    string lastName = commandTokens[1];
                    int age = int.Parse(commandTokens[2]);
                    decimal percent = decimal.Parse(commandTokens[3]);

                    Person person = new Person(firstName, lastName, age, percent);

                    people.Add(person);
                }

                decimal percentage = decimal.Parse(Console.ReadLine());

                people
                    .ForEach(p => p.IncreaseSalary(percentage));

                people
                    .ForEach(p => Console.WriteLine(p.ToString()));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
