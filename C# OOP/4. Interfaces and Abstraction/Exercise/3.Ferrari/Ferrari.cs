using _3.Ferrari.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string Model => "488-Spider";

        public string DriverName { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.DriverName}";
        }
    }
}
