using _6.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main()
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string[] tokens =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "End")
                {
                    break;
                }

                if (tokens[0].ToLower() == "citizen")
                {
                    string name = tokens[1];
                    string age = tokens[2];
                    string id = tokens[3];
                    string birthday = tokens[4];

                    IBirthable citizen = new Citizen(name, age, id, birthday);

                    birthables.Add(citizen);
                }

                else if (tokens[0].ToLower() == "pet")
                {

                    string name = tokens[1];
                    string birthday = tokens[2];

                    IBirthable pet = new Pet(name, birthday);

                    birthables.Add(pet);
                }
            }

            string year = Console.ReadLine();

            List<string> birthdates = birthables
                .Where(x => x.Birthdate.EndsWith(year))
                .Select(x => x.Birthdate)
                .ToList();

            if (birthdates.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, birthdates));
            }
        }
    }
}
