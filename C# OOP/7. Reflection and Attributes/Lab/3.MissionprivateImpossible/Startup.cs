using System;

namespace _3.MissionprivateImpossible
{
    public class Startup
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string result = spy.RevealPrivateMethods("Hacker");

            Console.WriteLine(result);
        }
    }
}
