using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] tokens =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(tokens[0], int.Parse(tokens[1]));
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
