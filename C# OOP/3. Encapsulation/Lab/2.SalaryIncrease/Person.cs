using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid age.");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            private set
            {
                if (value < 560)
                {
                    throw new ArgumentException("Invalid salary.");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            percentage = this.Age < 30 ? percentage / 2 : percentage;

            this.Salary += this.Salary * percentage / 100;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
