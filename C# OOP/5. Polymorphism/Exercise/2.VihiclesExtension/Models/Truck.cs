using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VihiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_CONSUMPTION = 1.6;

        private const double FUEL_QUANTITY_DECREASEMENT = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + AIR_CONDITIONER_FUEL_CONSUMPTION, tankCapacity)
        {
        }

        public override void RefueledAmountOfFuel(double amountOfFuel)
        {
            base.RefueledAmountOfFuel(amountOfFuel);
            this.FuelQuantity -= (amountOfFuel * FUEL_QUANTITY_DECREASEMENT);
        }
    }
}
