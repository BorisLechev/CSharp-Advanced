using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeight = 1.00;

        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => TigerWeight;

        protected override ICollection<Type> AllowedFood { get; }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
