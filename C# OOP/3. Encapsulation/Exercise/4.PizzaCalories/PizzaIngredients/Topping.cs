using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories.PizzaIngredients
{
    public class Topping
    {
        private const int CALORIES_PER_GRAM = 2;

        private string type;

        private double weightInGrams;

        public Topping(string type, double weightInGrams)
        {
            this.Type = type;
            this.WeightInGrams = weightInGrams;
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                Validator.ValidateToppingType(value);
                this.type = value;
            }
        }

        public double WeightInGrams
        {
            get
            {
                return this.weightInGrams;
            }

            private set
            {
                Validator.ValidateToppingWeight(value, this.Type);
                this.weightInGrams = value;
            }
        }

        public double Calories => GetCalories();

        public double GetCalories()
        {
            double toppingModifier = 0;

            switch (this.Type.ToLower())
            {
                case "meat":
                    toppingModifier = 1.2;
                    break;
                case "veggies":
                    toppingModifier = 0.8;
                    break;
                case "cheese":
                    toppingModifier = 1.1;
                    break;
                case "sauce":
                    toppingModifier = 0.9;
                    break;
                default:
                    break;
            }

            return CALORIES_PER_GRAM * this.WeightInGrams * toppingModifier;
        }
    }
}
