using System;
using System.Collections.Generic;
using System.Text;

namespace _3.ShoppingSpree
{
    public class Product
    {
        private string name;

        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateName(value);
                this.name = value;
            }
        }

        public decimal Cost { get; set; }
    }
}
