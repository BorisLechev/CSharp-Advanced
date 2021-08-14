using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Parking
{
    public class Parking
    {
        private readonly List<Car> carsList;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.carsList = new List<Car>();
        }

        public string Type { get; private set; }

        public int Capacity { get; private set; }

        public int Count
        {
            get => this.carsList.Count;
        }

        public void Add(Car car)
        {
            if (this.Capacity > this.Count)
            {
                this.carsList.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (this.carsList.Any(x => x.Manufacturer == manufacturer) &&
                this.carsList.Any(x => x.Model == model))
            {
                Car car = this.carsList
                    .Find(x => x.Manufacturer == manufacturer && x.Model == model);
                this.carsList.Remove(car);

                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            Car car = this.carsList.OrderByDescending(x => x.Year).FirstOrDefault();
            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = this.carsList
                    .Find(x => x.Manufacturer == manufacturer && x.Model == model);

            return car;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var item in this.carsList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
