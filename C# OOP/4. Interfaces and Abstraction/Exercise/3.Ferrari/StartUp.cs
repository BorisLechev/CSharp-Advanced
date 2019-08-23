using _3.Ferrari.Interfaces;
using System;

namespace _3.Ferrari
{
    public class StartUp
    {
        public static void Main()
        {
            string driverName = Console.ReadLine();

            ICar ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari.ToString());
        }
    }
}
