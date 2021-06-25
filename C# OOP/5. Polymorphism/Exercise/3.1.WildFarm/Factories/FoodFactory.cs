using _3._1.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1.WildFarm.Factories
{
    public class FoodFactory
    {
        // Factory pattern
        public Food CreateFood(string type, params string[] foodArgs)
        {
            string foodType = type.ToLower();
            int quantity = int.Parse(foodArgs[0]);

            switch (foodType)
            {
                case "fruit":
                    return new Fruit(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);
                case "vegetable":
                    return new Vegetable(quantity);
                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
