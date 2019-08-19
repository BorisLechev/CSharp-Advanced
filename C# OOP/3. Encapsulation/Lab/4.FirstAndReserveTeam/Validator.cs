using System;

namespace PersonsInfo
{
    public class Validator
    {
        public static void ValidateName(string name, string nameType)
        {
            if (name.Length < 3)
            {
                throw new ArgumentException($"{nameType} name cannot contain fewer than 3 symbols!");
            }
        }

        public static void ValidateAge(int age)
        {
            if (age <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
        }

        public static void ValidateSalary(decimal salary)
        {
            if (salary < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
        }
    }
}
