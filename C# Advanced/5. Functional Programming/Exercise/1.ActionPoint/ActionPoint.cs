using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string> print = el => Console.WriteLine(el);

            Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .ForEach(el => print(el));
        }
    }
}
