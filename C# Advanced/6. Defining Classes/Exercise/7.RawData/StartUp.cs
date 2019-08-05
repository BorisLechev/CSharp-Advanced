using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] tokens =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                double tire1Pressure = double.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);
                double tire2Pressure = double.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);
                double tire3Pressure = double.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);
                double tire4Pressure = double.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Tire firstTire = new Tire(tire1Pressure, tire1Age);
                Tire secondTire = new Tire(tire2Pressure, tire2Age);
                Tire thirdTire = new Tire(tire3Pressure, tire3Age);
                Tire fourthTire = new Tire(tire4Pressure, tire4Age);

                Tire[] tires =
                {
                    firstTire,
                    secondTire,
                    thirdTire,
                    fourthTire
                };

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars.Where(c => c.Cargo.CargoType == "fragile" 
                    && c.Tires.Any(t => t.TirePressure < 1)).ToList();
            }

            else if (command == "flamable")
            {
                cars = cars.Where(c => c.Cargo.CargoType == "flamable"
                    && c.Engine.EnginePower > 250).ToList();
            }

            cars
                .ForEach(c => Console.WriteLine(c.Model));
        }
    }
}
