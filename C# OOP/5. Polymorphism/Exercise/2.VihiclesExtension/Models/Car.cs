using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VihiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + AIR_CONDITIONER_FUEL_CONSUMPTION, tankCapacity)
        {
        }
    }
}
