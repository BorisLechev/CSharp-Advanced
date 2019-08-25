using _3.WildFarm.Models.Foods.Entities;
using System;
using System.Collections.Generic;

namespace _3.WildFarm.Models.Animals.Entities
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        protected override List<Type> PreferredFoodTypes =>
            new List<Type> { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        protected override double WeightMultiplier => 0.35;
    }
}
