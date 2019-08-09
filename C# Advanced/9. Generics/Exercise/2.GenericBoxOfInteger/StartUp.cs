using System;

namespace _2.GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int numberOfNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfNumbers; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(box.ToString());
        }
    }
}
