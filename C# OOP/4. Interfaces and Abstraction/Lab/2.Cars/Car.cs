using _2.Cars.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Cars
{
    public abstract class Car : ICar
    {
        public string Model { get; set; }

        public string Color { get; set; }

        public virtual string Start()
        {
            return "Engine start";
        }

        public virtual string Stop()
        {
            return "Breaaak!";
        }
    }
}
