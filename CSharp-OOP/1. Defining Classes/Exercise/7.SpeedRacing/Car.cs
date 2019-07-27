using System;

public class Car
{
    public string Model { get; set; }

    public double FuelAmount { get; set; }

    public double FuelConsumptionFor1Km { get; set; }

    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumptionFor1Km, double distanceTraveled)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionFor1Km = fuelConsumptionFor1Km;
        this.DistanceTraveled = distanceTraveled;
    }

    public void IfTheCarCanMoveTheDistance(double amountOfKm)
    {
        if (this.FuelAmount >= amountOfKm * this.FuelConsumptionFor1Km)
        {
            double usedFuel = amountOfKm * this.FuelConsumptionFor1Km;
            this.FuelAmount -= usedFuel;
            this.DistanceTraveled += amountOfKm;
        }

        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}