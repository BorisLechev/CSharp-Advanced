using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories.PizzaIngredients
{
    public class Dough
    {
        private const int CALORIES_PER_GRAM = 2;

        private string flourType;

        private string bakingTechnique;

        private double wieghtInGrams;

        public Dough(string flourType, string bakingTechnique, double weightInGrams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.WeightInGrams = weightInGrams;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }

            private set
            {
                Validator.ValidateFlourType(value);
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }

            private set
            {
                Validator.ValidateBakingTechnique(value);
                this.bakingTechnique = value;
            }
        }

        public double WeightInGrams
        {
            get
            {
                return this.wieghtInGrams;
            }

            private set
            {
                Validator.ValidateWeight(value);
                this.wieghtInGrams = value;
            }
        }

        public double Calories => GetCalories();

        public double GetCalories()
        {
            double flourModifier = this.FlourType.ToLower() == "white" ? 1.5 : 1;

            double bakingModifier = 0;

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingModifier = 0.9;
                    break;
                case "chewy":
                    bakingModifier = 1.1;
                    break;
                case "homemade":
                    bakingModifier = 1;
                    break;
                default:
                    break;
            }

            double calories = (CALORIES_PER_GRAM * this.WeightInGrams) * flourModifier * bakingModifier;

            return calories;
        }
    }
}
