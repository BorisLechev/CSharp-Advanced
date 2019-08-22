using _2.Cars.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int batteries)
        {
            this.Battery = batteries;
        }

        public int Battery { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries")
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
