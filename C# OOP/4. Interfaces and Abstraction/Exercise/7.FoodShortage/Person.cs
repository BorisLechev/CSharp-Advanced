using _7.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.FoodShortage
{
    public abstract class Person : IBuyer
    {
        private string name;

        private string age;

        private HashSet<string> names = new HashSet<string>();

        public Person(string name, string age)
        {
            this.Name = name;
            this.age = age;
            this.Food = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                Validator.ValidateIsNameAvailable(this.names, value);
                this.name = value;
            }
        }

        public int Food { get; protected set; }

        public abstract void BuyFood();

        private void AddName(string name)
        {
            this.names.Add(name);
        }
    }
}
