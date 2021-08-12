using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
using System;

namespace Bakery.Models.BakedFoods
{
    //The Food is a base class for any type of food and it should not be able to be instantiated
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        public BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public int Portion 
        {
            get => this.portion;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }

                this.portion = value;
            }
        }

        public decimal Price 
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Portion}g - {this.Price:F2}";
        }
    }
}
