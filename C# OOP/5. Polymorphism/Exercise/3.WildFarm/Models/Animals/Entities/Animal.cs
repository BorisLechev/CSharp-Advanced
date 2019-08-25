using _3.WildFarm.Exceptions;
using _3.WildFarm.Models.Animals.Contracts;
using _3.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;

namespace _3.WildFarm.Models.Animals.Entities
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract List<Type> PreferredFoodTypes { get; } // предпочитаните храни на животното

        protected abstract double WeightMultiplier { get; }

        public abstract string AskForFood(); // за издаване на звуци, но Animal няма звук, затова abstract без тяло

        public void Feed(IFood food) // IFood за да има абстракция, защото не знам каква ще е (vegetable etc.)
        {
            if (!this.PreferredFoodTypes.Contains(food.GetType()))
            {
                throw new InvalidOperationException(
                    String.Format(ExceptionMessages.InvalidFoodTypeException, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
