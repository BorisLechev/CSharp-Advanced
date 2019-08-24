using System;
using System.Collections.Generic;
using System.Text;

namespace _1.MathOperation
{
    public class Engine
    {
        public void Run()
        {
            IMathOperations mathOperation = new MathOperations();

            Console.WriteLine(mathOperation.Add(2, 3));
            Console.WriteLine(mathOperation.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mathOperation.Add(2.2M, 3.3M, 4.4M));
        }
    }
}
