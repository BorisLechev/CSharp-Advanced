using _3.WildFarm.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Models.Animals.Entities
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        protected override List<Type> PreferredFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 0.4;

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
