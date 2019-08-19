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

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.ValidateName(value, "First");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                Validator.ValidateName(value, "Last");
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                Validator.ValidateAge(value);
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
                Validator.ValidateSalary(value);
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
