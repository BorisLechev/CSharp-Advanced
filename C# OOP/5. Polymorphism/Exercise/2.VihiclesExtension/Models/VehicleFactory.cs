using System;
using System.Collections.Generic;
using System.Text;

namespace _2.VihiclesExtension.Models
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string[] data)
        {
            string type = data[0];
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);
            double tankCapacity = double.Parse(data[3]);

            if (type == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else if (type == "Truck")
            {
                return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }

            else
            {
                return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
        }
    }
}
