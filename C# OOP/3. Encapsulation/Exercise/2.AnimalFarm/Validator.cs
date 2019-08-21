using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm
{
    public class Validator
    {
        public static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
        }

        public static void ValidateAge(int age, int minAge, int maxAge)
        {
            if (age < minAge || age > maxAge)
            {
                throw new ArgumentException($"Age should be between {minAge} and {maxAge}.");
            }
        }
    }
}
