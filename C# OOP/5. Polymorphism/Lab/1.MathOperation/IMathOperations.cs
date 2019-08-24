using System;
using System.Collections.Generic;
using System.Text;

namespace _1.MathOperation
{
    public interface IMathOperations
    {
        int Add(int firstNumber, int secondNumber);

        double Add(double firstNumber, double secondNumber, double thirdNumber);

        decimal Add(decimal firstNumber, decimal secondNumber, decimal thirdNumber);
    }
}
