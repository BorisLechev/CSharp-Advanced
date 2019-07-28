using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.AutoRepairAndService
{
    class AutoRepairAndService
    {
        static void Main(string[] args)
        {
            string[] sequence = 
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(sequence);
            Stack<string> servedCars = new Stack<string>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split("-");

                if (commands[0] == "Service")
                {
                    if (queue.Any())
                    {
                        string servedCar = queue.Dequeue();
                        servedCars.Push(servedCar);
                        Console.WriteLine($"Vehicle {servedCar} got served.");
                    }
                }

                else if (commands[0] == "CarInfo")
                {
                    string modelName = commands[1];

                    if (servedCars.Contains(modelName))
                    {
                        Console.WriteLine("Served.");
                    }

                    else
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                }

                else if (commands[0] == "History")
                {
                    Console.WriteLine(string.Join(", ", servedCars));
                }

                else if (commands[0] == "End")
                {
                    if (queue.Any())
                    {
                        Console.WriteLine($"Vehicles for service: {string.Join(", ", queue)}");
                    }

                    Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
                    return;
                }
            }
        }
    }
}
