using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VihiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_CONSUMPTION = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONDITIONER_FUEL_CONSUMPTION, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= AIR_CONDITIONER_FUEL_CONSUMPTION;

            return base.Drive(distance);
        }
    }
}
