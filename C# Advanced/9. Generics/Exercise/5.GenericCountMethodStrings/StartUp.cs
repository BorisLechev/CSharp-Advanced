using System;
using System.Linq;

namespace _5.GenericCountMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int numberOfElements = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfElements; i++)
            {
                string element = Console.ReadLine();

                box.Add(element);
            }

            string elementForComparision = Console.ReadLine();
            box.CountOfElementsGreaterThan(elementForComparision);

            Console.WriteLine(box.Counter);
        }
    }
}
