using System;
using System.Collections.Generic;
using System.Text;

namespace _3.ShoppingSpree
{
    public class Person
    {
        private string name;

        private decimal money;

        private List<string> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<string>();
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

        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                Validator.ValidateMoney(value);
                this.money = value;
            }
        }

        public List<string> Products { get; private set; }

        public void BuyProduct(Person person, Product product)
        {
            if (person.Money < product.Cost)
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
                return;
            }

            person.Products.Add(product.Name);
            person.Money -= product.Cost;
            Console.WriteLine($"{person.Name} bought {product.Name}");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Name} - ");

            if (this.Products.Count == 0)
            {
                sb.Append("Nothing bought");
            }

            else
            {
                sb.Append(String.Join(", ", this.Products));
            }

            return sb.ToString();
        }
    }
}
