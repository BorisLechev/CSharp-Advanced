using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person firstPerson = new Person(),
                secondPerson = new Person(15),
                thirdPerson = new Person("Hiro", 21);

            Console.WriteLine($"Name: {firstPerson.Name}, Age: {firstPerson.Age}");
            Console.WriteLine($"Name: {secondPerson.Name}, Age: {secondPerson.Age}");
            Console.WriteLine($"Name: {thirdPerson.Name}, Age: {thirdPerson.Age}");
        }
    }
}
