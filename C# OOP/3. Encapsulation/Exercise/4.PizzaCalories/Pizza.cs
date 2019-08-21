using _4.PizzaCalories.PizzaIngredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.PizzaCalories
{
    public class Pizza
    {
        private string name;

        private List<Topping> toppings;

        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
            this.Dough = dough;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidatePizzaName(value);
                this.name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }

        public int NumberOfToppings => this.toppings.Count;

        public double TotalCalories => GetTotalCalories();

        public void AddTopping(Topping topping)
        {
            Validator.ValidateNumberOfToppings(this.NumberOfToppings);

            this.toppings.Add(topping);
        }

        private double GetTotalCalories()
        {
            double doughCalories = this.dough.Calories;
            double toppingCalories = this.toppings.Select(t => t.Calories).Sum();

            return doughCalories + toppingCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}
