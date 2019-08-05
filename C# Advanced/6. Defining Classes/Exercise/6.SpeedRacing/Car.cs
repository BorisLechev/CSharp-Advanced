using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPer1Km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPer1Km;
            this.TravelledDistance = 0;
        }

        public void CanCarMoveTheDistance(double amountOfKm)
        {
            double fuelNeeded = this.FuelConsumptionPerKilometer * amountOfKm;

            if (this.FuelAmount >= fuelNeeded)
            {
                this.FuelAmount -= fuelNeeded;
                this.TravelledDistance += amountOfKm;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }
    }
}
