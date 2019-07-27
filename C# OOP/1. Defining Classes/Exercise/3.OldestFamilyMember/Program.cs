﻿using System;

public class Program
{
    public static void Main()
    {
        Family family = new Family();

        int numberOfPersons = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPersons; i++)
        {
            var input = Console.ReadLine().Split(" ");

            string name = input[0];
            int age = int.Parse(input[1]);

            family.AddMember(new Person(name, age));
        }

        Person oldestMember = family.GetOldestMember();

        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}