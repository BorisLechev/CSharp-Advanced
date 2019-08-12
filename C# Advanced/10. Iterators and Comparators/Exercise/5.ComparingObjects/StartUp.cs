using System;
using System.Collections.Generic;

namespace _5.ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int nthPerson = int.Parse(Console.ReadLine());

            int countOfMatches = 1; // броя и мен
            int numberOfNotEqualPeople = 0;

            Person targetPerson = people[nthPerson - 1];

            foreach (Person currentPerson in people)
            {
                if (currentPerson == targetPerson) // не сравняваме еднин и същ човек
                {
                    continue;
                }

                if (currentPerson.CompareTo(targetPerson) == 0)
                {
                    countOfMatches++;
                }

                else
                {
                    numberOfNotEqualPeople++;
                }
            }

            if (countOfMatches > 1)
            {
                Console.WriteLine($"{countOfMatches} {numberOfNotEqualPeople} {people.Count}");
            }

            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
