using System;
using System.Collections.Generic;
using System.Text;

namespace _7.FoodShortage
{
    public class Validator
    {
        public static void ValidateIsNameAvailable(HashSet<string> names, string name)
        {
            if (!names.Contains(name))
            {
                throw new ArgumentException("This name is not avilable.");
            }
        }
    }
}
