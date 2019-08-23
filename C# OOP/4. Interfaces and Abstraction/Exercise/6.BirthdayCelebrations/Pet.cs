using _6.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6.BirthdayCelebrations
{
    public class Pet : INamable, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
