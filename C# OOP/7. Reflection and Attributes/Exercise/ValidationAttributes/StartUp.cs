using System;
using ValidationAttributes.Entities;
using ValidationAttributes.Utilities;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main()
        {
            Person person = new Person
             (
                 null,
                 -1
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
