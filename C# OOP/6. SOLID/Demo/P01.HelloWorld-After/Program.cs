using P01._HelloWorld;
using System;

namespace P01.HelloWorld_After
{
    class Program
    {
        static void Main(string[] args)
        {
            var greeting = new HelloWorld();

            greeting.Greeting("pesho", DateTime.Now);
        }
    }
}
