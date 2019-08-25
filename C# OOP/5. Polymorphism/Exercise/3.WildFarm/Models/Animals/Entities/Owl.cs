using _3.WildFarm.Models.Foods.Entities;
using System;
using System.Collections.Generic;

namespace _3.WildFarm.Models.Animals.Entities
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot hoot";
        }

        protected override List<Type> PreferredFoodTypes => new List<Type> { typeof(Meat) }; // typeof работи с класа GetType() с инстанцията

        protected override double WeightMultiplier => 0.25;
    }
}
