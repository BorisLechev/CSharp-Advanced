using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double OwlWeight = 0.25;

        public Owl(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        protected override double WeightMultiplier => OwlWeight;

        protected override ICollection<Type> AllowedFood { get; }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot hoot");
        }
    }
}
