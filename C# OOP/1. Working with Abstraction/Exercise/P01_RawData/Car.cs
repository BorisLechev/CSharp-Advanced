using System.Collections.Generic;

namespace P01_RawData
{
    public class Car
    {
        public Car(string model,
            int engineSpeed,
            int enginePower,
            int cargoWeight,
            string cargoType,
            params Tire[] tires) // params може да приема различен брой параметри
        {
            this.Model = model;
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;

            //TODO: Add Tires
            this.Tires = tires;
            //this.tires = new KeyValuePair<double, int>[] { KeyValuePair.Create(tire1Pressure, tire1Age), KeyValuePair.Create(tire2Pressure, tire2Age), KeyValuePair.Create(tire3Pressure, tire3age), KeyValuePair.Create(tire4Pressure, tire4age) };
        }

        public string Model { get; set; }

        public int EngineSpeed { get; set; }

        public int EnginePower { get; set; }

        public int CargoWeight { get; set; }

        public string CargoType { get; set; }

        public Tire[] Tires { get; set; }
    }
}
