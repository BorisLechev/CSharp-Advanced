using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInput =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(carInput[0], double.Parse(carInput[1]), double.Parse(carInput[2]));
                cars.Add(car);
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens =
                    input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car currentCar = cars.Find(c => c.Model == tokens[1]);

                currentCar.CanCarMoveTheDistance(double.Parse(tokens[2]));
            }

            cars
                .ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.TravelledDistance}"));
        }
    }
}
