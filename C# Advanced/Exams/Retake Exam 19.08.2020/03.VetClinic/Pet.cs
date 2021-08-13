﻿namespace _03.VetClinic
{
    public class Pet
    {
        public Pet(string name, int age, string owner)
        {
            this.Name = name;
            this.Age = age;
            this.Owner = owner;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Owner { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.Name} Age: {this.Age} Owner: {this.Owner}";
        }
    }
}
