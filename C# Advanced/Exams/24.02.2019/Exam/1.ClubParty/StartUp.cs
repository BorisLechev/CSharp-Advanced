using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ClubParty
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            int currentCapacity = 0;

            string[] array =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> elements = new Stack<string>(array);
            Queue<string> halls = new Queue<string>();
            List<int> people = new List<int>();

            while (elements.Count > 0)
            {
                string lastElement = elements.Pop();
                bool isNumber = Int32.TryParse(lastElement, out int parsedNumber);

                if (!isNumber)
                {
                    halls.Enqueue(lastElement);
                }

                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (currentCapacity + parsedNumber > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {String.Join(", ", people)}");
                        people.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Count > 0)
                    {
                        people.Add(parsedNumber);
                        currentCapacity += parsedNumber;
                    }
                }
            }
        }
    }
}
