using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten)
        {
        }

        public double WingSize
        {
            get { return wingSize; }
            private set { wingSize = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
