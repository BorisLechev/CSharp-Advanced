using System;

namespace _8.Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personalData =
                Console.ReadLine()
                .Split();

            string name = personalData[0] + " " + personalData[1];

            Threeuple<string, string, string> firstUple =
                new Threeuple<string, string, string>(name, personalData[2], personalData[3]);

            string[] personalBeerConsumation =
                Console.ReadLine()
                .Split();
            bool isDrunk = personalBeerConsumation[2].ToLower() == "drunk";

            Threeuple<string, int, bool> secondUple =
                new Threeuple<string, int, bool>(personalBeerConsumation[0], int.Parse(personalBeerConsumation[1]), isDrunk);

            string[] bankBalance =
                Console.ReadLine()
                .Split();

            Threeuple<string, double, string> thirdUple =
                new Threeuple<string, double, string>(bankBalance[0], double.Parse(bankBalance[1]), bankBalance[2]);

            Console.WriteLine(firstUple.GetInfo());
            Console.WriteLine(secondUple.GetInfo());
            Console.WriteLine(thirdUple.GetInfo());
        }
    }
}
