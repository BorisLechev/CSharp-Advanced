using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption + AIR_CONDITIONER_FUEL_CONSUMPTION;
        }
    }
}
