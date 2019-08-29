using System;

namespace _2.HighQualityMistakes
{
    public class Startup
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string result = spy.AnalyzeAcessModifiers("Hacker");

            Console.WriteLine(result);
        }
    }
}
