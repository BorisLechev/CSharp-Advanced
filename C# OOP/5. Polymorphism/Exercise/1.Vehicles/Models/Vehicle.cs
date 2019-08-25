namespace _1.Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double DrivenDistance { get; private set; } = 0;

        public string Drive(double distance)
        {
            double neededLiters = distance * this.FuelConsumption;

            if (this.FuelQuantity >= neededLiters)
            {
                this.FuelQuantity -= neededLiters;
                this.DrivenDistance = distance;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void RefueledAmountOfFuel(double amountOfFuel) // virtual, за да може да се override-не в Truck
        {
            this.FuelQuantity += amountOfFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
