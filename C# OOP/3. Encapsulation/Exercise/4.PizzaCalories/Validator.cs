using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Validator
    {
        public static void ValidateFlourType(string doughType)
        {
            if (doughType.ToLower() != "white" && doughType.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        public static void ValidateBakingTechnique(string bakingTechnique)
        {
            if (bakingTechnique.ToLower() != "crispy" && bakingTechnique.ToLower() != "chewy" 
                && bakingTechnique.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        public static void ValidateWeight(double weightInGrams)
        {
            if (weightInGrams < 1 || weightInGrams > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
        }

        public static void ValidateToppingType(string type)
        {
            if (type.ToLower() != "meat" && type.ToLower() != "veggies" && type.ToLower() != "cheese" 
                && type.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }
        }

        public static void ValidateToppingWeight(double weightInGrams, string typeName)
        {
            if (weightInGrams < 1 || weightInGrams > 50)
            {
                throw new ArgumentException($"{typeName} weight should be in the range [1..50].");
            }
        }

        public static void ValidatePizzaName(string name)
        {
            if (name.Length < 1 || name.Length > 15 || string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
        }

        public static void ValidateNumberOfToppings(int numberOfToppings)
        {
            if (numberOfToppings < 0 || numberOfToppings > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
    }
}
