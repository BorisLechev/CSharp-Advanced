using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Cars
{
    public class Seat : Car
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.Color} Seat {this.Model}")
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
