using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Validator
    {
        public static void ValidateBoxSide(double boxSide, string boxSideName)
        {
            if (boxSide <= 0)
            {
                throw new ArgumentException($"{boxSideName} cannot be zero or negative.");
            }
        }
    }
}
