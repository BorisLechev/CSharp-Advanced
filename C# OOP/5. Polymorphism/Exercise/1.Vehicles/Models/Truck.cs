namespace _1.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITIONER_FUEL_CONSUMPTION = 1.6;

        private const double FUEL_QUANTITY_DECREASEMENT = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + AIR_CONDITIONER_FUEL_CONSUMPTION;
        }

        public override void RefueledAmountOfFuel(double amountOfFuel)
        {
            base.RefueledAmountOfFuel(amountOfFuel * FUEL_QUANTITY_DECREASEMENT);
        }
    }
}
