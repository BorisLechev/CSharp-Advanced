using NeedForSpeed.Cars;
using NeedForSpeed.Motorcycles;
using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main()
        {
            SportCar sportCar = new SportCar(300, 20);
            Motorcycle motorcycle = new Motorcycle(33, 20);

            Console.WriteLine(sportCar.FuelConsumption);
            Console.WriteLine(motorcycle.FuelConsumption);

            sportCar.Drive(2);
        }
    }
}
