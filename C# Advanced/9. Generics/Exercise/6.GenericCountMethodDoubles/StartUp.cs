using System;

namespace _6.GenericCountMethodDoubles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int numberOfElements = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfElements; i++)
            {
                double element = double.Parse(Console.ReadLine());

                box.Add(element);
            }

            double elementForComparision = double.Parse(Console.ReadLine());
            box.CountOfElementsGreaterThan(elementForComparision);

            Console.WriteLine(box.Counter);
        }
    }
}
