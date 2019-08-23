using _6.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6.BirthdayCelebrations
{
    public class Citizen : IIdentifiable, INamable, IBirthable
    {
        private string age;

        public Citizen(string name, string age, string id, string birthdate)
        {
            this.Name = name;
            this.age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
