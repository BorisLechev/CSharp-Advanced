using _3._1.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeight = 0.35;

        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
            this.AllowedFood = new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit),
                typeof(Meat),
                typeof(Seeds)
            };
        }

        protected override double WeightMultiplier => HenWeight;

        protected override ICollection<Type> AllowedFood { get; }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
