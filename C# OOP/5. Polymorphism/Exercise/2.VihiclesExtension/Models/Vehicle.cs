using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VihiclesExtension.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            protected set
            {
                //if (value > this.TankCapacity)
                //{
                //    this.fuelQuantity = 0;
                //}

                //else
                //{
                    this.fuelQuantity = value;
                //}
            }
        }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public double DrivenDistance { get; private set; } = 0;

        public string Drive(double distance)
        {
            double neededLiters = distance * this.FuelConsumption;

            if (this.FuelQuantity >= neededLiters)
            {
                this.FuelQuantity -= neededLiters;
                this.DrivenDistance += distance;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void RefueledAmountOfFuel(double amountOfFuel) // virtual, за да може да се override-не в Truck
        {
            if (amountOfFuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }

            if (this.TankCapacity < amountOfFuel + this.FuelQuantity)
            {
                throw new InvalidOperationException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

            this.FuelQuantity += amountOfFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
