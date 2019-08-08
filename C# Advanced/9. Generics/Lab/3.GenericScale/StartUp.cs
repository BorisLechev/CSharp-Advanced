using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var firstScale = new EqualityScale<int>(5, 5);

            Console.WriteLine(firstScale.AreEqual());
            firstScale.WhichIsHeavier();

            var secondScale = new EqualityScale<int>(8, 3);

            Console.WriteLine(secondScale.AreEqual());
            secondScale.WhichIsHeavier();
        }
    }
}
