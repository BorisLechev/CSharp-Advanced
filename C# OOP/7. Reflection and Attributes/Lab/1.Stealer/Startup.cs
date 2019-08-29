using System;

namespace _1.Stealer
{
    public class Startup
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string result = spy.StealFieldInfo("Hacker", "username", "password");

            Console.WriteLine(result);
        }
    }
}
