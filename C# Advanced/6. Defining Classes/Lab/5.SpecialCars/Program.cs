using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SpecialCars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] currentTirePack = GetTirePack(tireData);

                tires.Add(currentTirePack);
            }

            string engineInput = String.Empty;

            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                string[] engineData = engineInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);

                engines.Add(currentEngine);
            }

            string carData = String.Empty;
            List<Car> cars = new List<Car>();

            while ((carData = Console.ReadLine()) != "Show special")
            {
                string[] tokens = carData.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tireIndex = int.Parse(tokens[6]);

                if ((engineIndex >= 0 && engineIndex <= engines.Count - 1) 
                    && (tireIndex >= 0 && tireIndex <= tires.Count - 1))
                {
                    Engine engine = engines[engineIndex];
                    Tire[] tireSet = tires[tireIndex];
                    Car currentCar = new Car(tokens[0], tokens[1], year, fuelQuantity, fuelConsumption, engine, tireSet);
                    cars.Add(currentCar);
                }
            }

            List<Car> specialCars = cars
                .Where(c => c.Year >= 2017
                       && c.Engine.HorsePower > 330
                       && c.Tires.Select(p => p.Pressure).Sum() >= 9 && c.Tires.Select(p => p.Pressure).Sum() <= 10)
                .ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }

        private static Tire[] GetTirePack(string[] tireData)
        {
            Tire[] tirePack = new Tire[4];
            int indexInTirePack = 0;

            for (int i = 0; i < tireData.Length - 1; i += 2)
            {
                int year = int.Parse(tireData[i]);
                double pressure = double.Parse(tireData[i + 1]);

                tirePack[indexInTirePack] = new Tire(year, pressure);
                indexInTirePack++;
            }

            return tirePack;
        }
    }
}
