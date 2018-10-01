using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            var carInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            cars.Add(new Car(carInput[0], double.Parse(carInput[1]), double.Parse(carInput[2]), 0));
        }

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var currentInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string carModel = currentInput[1];
            double amountOfKm = double.Parse(currentInput[2]);

            Car currentCar = cars.Find(c => c.Model == carModel);
            currentCar.IfTheCarCanMoveTheDistance(amountOfKm);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }
}