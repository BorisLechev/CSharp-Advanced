using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            try
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                    cmdArgs[1],
                                    int.Parse(cmdArgs[2]),
                                    decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Team team = new Team("BestTeam");
        persons.ForEach(p => team.AddPlayer(p));

        Console.WriteLine(team.ToString());
    }
}