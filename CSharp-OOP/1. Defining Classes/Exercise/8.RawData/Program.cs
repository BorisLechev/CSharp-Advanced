using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfLines; i++)
        {
            var splittedInput = Console.ReadLine().Split(" ");

            string model = splittedInput[0];
            int engineSpeed = int.Parse(splittedInput[1]);
            int enginePower = int.Parse(splittedInput[2]);
            int cargoWeight = int.Parse(splittedInput[3]);
            string cargoType = splittedInput[4];
            List<Tire> tires = new List<Tire>();

            for (int j = 5; j < splittedInput.Length; j += 2)
            {
                double pressure = double.Parse(splittedInput[j]);
                int age = int.Parse(splittedInput[j + 1]);

                tires.Add(new Tire(pressure, age));
            }

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            cars.Add(new Car(model, engine, cargo, tires));
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            cars.Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
        }

        else if (command == "flamable")
        {
            cars.Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250)
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
        }
    }
}