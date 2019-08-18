using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Animals
{
    public class Tomcat : Animal
    {
        public Tomcat(string name, string age, string gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
