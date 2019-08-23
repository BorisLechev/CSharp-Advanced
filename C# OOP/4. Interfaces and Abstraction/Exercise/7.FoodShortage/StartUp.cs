using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.FoodShortage
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> buyers = new List<Person>();
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                string age = input[1];

                try
                {
                    if (input.Length > 3)
                    {
                        string id = input[2];
                        string birthdate = input[3];

                        Citizen citizen = new Citizen(name, age, id, birthdate);
                        buyers.Add(citizen);
                    }

                    else
                    {
                        string group = input[2];

                        Rebel rebel = new Rebel(name, age, group);
                        buyers.Add(rebel);
                    }
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            string nameOfPersonBoughtFood = String.Empty;

            while ((nameOfPersonBoughtFood = Console.ReadLine()) != "End")
            {
                if (buyers.Any(b => b.Name == nameOfPersonBoughtFood))
                {
                    Person person = buyers.Find(b => b.Name == nameOfPersonBoughtFood);

                    person.BuyFood();
                }
            }

            int totalBoughtFood = buyers.Select(b => b.Food).Sum();

            Console.WriteLine(totalBoughtFood);
        }
    }
}
