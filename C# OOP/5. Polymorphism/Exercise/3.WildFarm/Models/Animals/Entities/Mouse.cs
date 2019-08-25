using _3.WildFarm.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Models.Animals.Entities
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        protected override List<Type> PreferredFoodTypes => new List<Type> { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightMultiplier => 0.1;

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
