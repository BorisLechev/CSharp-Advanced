
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeight = 0.40;

        public Dog(string name, double weight, int foodEaten, string livingRegion) 
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        protected override double WeightMultiplier => DogWeight;

        protected override ICollection<Type> AllowedFood { get; }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
