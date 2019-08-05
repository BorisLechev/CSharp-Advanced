using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDateAsStr = Console.ReadLine();
            string secondDateAsStr = Console.ReadLine();

            DateModifier dateModifier = new DateModifier(firstDateAsStr, secondDateAsStr);

            Console.WriteLine(dateModifier.CalculateDiffBetweenDates());
        }
    }
}
