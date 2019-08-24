using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Engine
    {
        public void Run()
        {
            Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Dog("Gosho", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
