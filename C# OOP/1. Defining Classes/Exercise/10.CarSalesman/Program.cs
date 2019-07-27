using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        List<Engine> engines = new List<Engine>();

        for (int i = 0; i < numberOfEngines; i++)
        {
            var engineData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string model = engineData[0];
            double power = double.Parse(engineData[1]);

            if (engineData.Count == 3)
            {
                if (double.TryParse(engineData[2], out double displacement))
                {
                    displacement = double.Parse(engineData[2]);
                    engines.Add(new Engine(model, power, displacement, "n/a"));
                }

                else
                {
                    string efficiency = engineData[2];

                    engines.Add(new Engine(model, power, 0.0, efficiency));
                }
            }

            else if (engineData.Count == 4)
            {
                double displacement = double.Parse(engineData[2]);
                string efficiency = engineData[3];

                engines.Add(new Engine(model, power, displacement, efficiency));
            }
        }

        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            var carData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string model = carData[0];
            Engine engine = engines.First(e => e.Model == carData[1]);

            if (carData.Count == 2)
            {
                cars.Add(new Car(model, engine));
            }

            else if (carData.Count == 3)
            {
                if (double.TryParse(carData[2], out double weight))
                {
                    weight = double.Parse(carData[2]);
                    cars.Add(new Car(model, engine, weight));
                }

                else
                {
                    cars.Add(new Car(model, engine, 0.0, carData[2]));
                }
            }

            else if (carData.Count == 4)
            {
                cars.Add(new Car(model, engine, double.Parse(carData[2]), carData[3]));
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}