using _3.WildFarm.Models.Foods.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.WildFarm.Models.Animals.Entities
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> PreferredFoodTypes => new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 1;

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
