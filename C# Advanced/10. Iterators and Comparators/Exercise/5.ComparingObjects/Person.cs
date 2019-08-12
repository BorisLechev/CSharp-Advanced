using System;
using System.Collections.Generic;
using System.Text;

namespace _5.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0) // не са еднакви
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age.CompareTo(other.Age) != 0) // не са еднакви
            {
                return this.Age.CompareTo(other.Age);
            }

            if (this.Town.CompareTo(other.Town) != 0) // не са еднакви
            {
                return this.Town.CompareTo(other.Town);
            }

            return 0;
        }
    }
}
