using _7.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.FoodShortage
{
    public class Rebel : Person
    {
        private const int VALUE_TO_INCREASE_FOOD = 10;
        private string rebelGroup;

        public Rebel(string name, string age, string rebelGroup)
            : base(name, age)
        {
            this.rebelGroup = rebelGroup;
        }

        public override void BuyFood()
        {
            this.Food += VALUE_TO_INCREASE_FOOD;
        }
    }
}
