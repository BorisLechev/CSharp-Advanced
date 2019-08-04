using System;

namespace _1.Car
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "Golf";
            car.Year = 2014;

            Console.WriteLine($"Make: {car.Make + Environment.NewLine}" +
                $"Model: {car.Model + Environment.NewLine}" +
                $"Year: {car.Year}");
        }
    }
}
