using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineData = 
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = engineData[0];
                double power = double.Parse(engineData[1]);
                Engine engine = new Engine(model, power);

                if (engineData.Length > 2)
                {
                    string thirdToken = engineData[2];
                    double doubleDisplacement;
                    bool isNumber = double.TryParse(thirdToken, out doubleDisplacement);

                    if (isNumber)
                    {
                        engine.Displacement = thirdToken;
                    }

                    else
                    {
                        engine.Efficiency = thirdToken;
                    }
                }

                if (engineData.Length > 3)
                {
                    string efficiency = engineData[3];

                    engine.Efficiency = efficiency;

                }

                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                string engine = carData[1];
                Car car = new Car(model, engines.FirstOrDefault(e => e.Model == engine));

                if (carData.Length > 2)
                {
                    string thirdToken = carData[2];
                    double weight;
                    bool isNumber = double.TryParse(thirdToken, out weight);

                    if (isNumber)
                    {
                        car.Weight = thirdToken;
                    }

                    else
                    {
                        car.Color = thirdToken;
                    }
                }

                if (carData.Length > 3)
                {
                    string color = carData[3];

                    car.Color = color;
                }

                cars.Add(car);
            }

            cars
                .ForEach(c => Console.WriteLine(c));
        }
    }
}
