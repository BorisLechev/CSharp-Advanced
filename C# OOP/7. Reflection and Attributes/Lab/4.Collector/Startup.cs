﻿using System;

namespace _4.Collector
{
    public class Startup
    {
        public static void Main()
        {
            Spy spy = new Spy();

            string result = spy.CollectGettersAndSetters("Hacker");

            Console.WriteLine(result);
        }
    }
}
