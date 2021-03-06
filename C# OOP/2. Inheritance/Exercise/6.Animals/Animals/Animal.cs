﻿using System;
using System.Text;

namespace Animals.Animals
{
    public class Animal
    {
        private string name;

        private string age;

        private string gender;

        public Animal(string name , string age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("Invalid input!");
                }

                this.Name = value;
            }
        }

        public string Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) 
                    || string.IsNullOrWhiteSpace(value) 
                    || (Int32.TryParse(value, out int ageNum) && ageNum < 0))
                {
                    throw new FormatException("Invalid input.");
                }

                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) 
                    || string.IsNullOrWhiteSpace(value) 
                    || (value.ToLower() != "male" && value.ToLower() != "female"))
                {
                    throw new FormatException("Invalid format.");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(this.GetType().Name);
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            result.Append(this.ProduceSound());

            return result.ToString();
        }
    }
}
