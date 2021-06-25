using _3._1.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace _3._1.WildFarm.Models.Animals
{
    public abstract class Animal
    {
        private string name;

        private double weight;

        private int foodEaten;

        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            private set { foodEaten = value; }
        }

        protected abstract double WeightMultiplier { get; }

        protected abstract ICollection<Type> AllowedFood { get; }

        public abstract void ProduceSound(); // за издаване на звуци, но Animal няма звук, затова abstract без тяло

        public void Eat(Food food)
        {
            if (this.AllowedFood.Contains(typeof(Food)) == false)
            {
                throw new InvalidOperationException(
                   String.Format("Invalid food type.", this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
