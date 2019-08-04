using System;
using System.Collections.Generic;
using System.Text;

namespace _4.CarEngineAndTires
{
    public class Car
    {
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity,
            double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption / 100;

            if (this.FuelQuantity - fuelNeeded > 0)
            {
                this.FuelQuantity -= fuelNeeded;
            }

            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Make: {this.Make}");
            builder.AppendLine($"Model: {this.Model}");
            builder.AppendLine($"Year: {this.Year}");

            return builder.ToString();
        }
    }
}
