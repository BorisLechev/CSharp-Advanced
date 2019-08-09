using System;
using System.Linq;

namespace _7.Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personalData =
                Console.ReadLine()
                .Split();

            string name = personalData[0] + " " + personalData[1];
            Tuple<string, string> firstTuple = new Tuple<string, string>(name, personalData[2]);

            string[] personalBeerConsumationCapacity =
                Console.ReadLine()
                .Split();

            Tuple<string, int> secondTuple = 
                new Tuple<string, int>(personalBeerConsumationCapacity[0],
                int.Parse(personalBeerConsumationCapacity[1]));

            string[] lastLine =
                Console.ReadLine()
                .Split()
                .ToArray();

            Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(lastLine[0]), double.Parse(lastLine[1]));

            Console.WriteLine(firstTuple.GetInfo());
            Console.WriteLine(secondTuple.GetInfo());
            Console.WriteLine(thirdTuple.GetInfo());
        }
    }
}
