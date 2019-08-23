using _10.ExplicitInterfaces.Contracts;
using _10.ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
