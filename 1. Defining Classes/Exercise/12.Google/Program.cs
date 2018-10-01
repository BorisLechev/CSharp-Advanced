using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> googleDatabase = new List<Person>();
        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var splittedInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string personName = splittedInput[0];

            switch (splittedInput[1])
            {
                case "company":
                    Company company = new Company(splittedInput[2], splittedInput[3], decimal.Parse(splittedInput[4]));
            }
        }
    }
}