using _7.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.FoodShortage
{
    public class Citizen : Person, IIdentifiable, IBirthable
    {
        private const int VALUE_TO_INCREASE_FOOD = 10;

        public Citizen(string name, string age, string id, string birthdate)
            : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public override void BuyFood()
        {
            this.Food += VALUE_TO_INCREASE_FOOD;
        }
    }
}
