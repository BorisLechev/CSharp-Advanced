using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeight = 0.30;

        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => CatWeight;

        protected override ICollection<Type> AllowedFood { get; }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
