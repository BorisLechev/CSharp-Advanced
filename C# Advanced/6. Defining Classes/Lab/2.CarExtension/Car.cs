using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarManufacturer
{
    public class Car
    {
        private string make;

        private string model;

        private int year;

        private double fuelQuantity;

        private double fuelConsumption;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

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
