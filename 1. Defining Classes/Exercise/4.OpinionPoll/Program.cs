using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var database = new List<Person>();
        int numberOfPersons = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPersons; i++)
        {
            var input = Console.ReadLine().Split(" ");

            string name = input[0];
            int age = int.Parse(input[1]);

            database.Add(new Person(name, age));
        }

        var output = database.Where(p => p.Age > 30).OrderBy(n => n.Name);

        foreach (var person in output)
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}