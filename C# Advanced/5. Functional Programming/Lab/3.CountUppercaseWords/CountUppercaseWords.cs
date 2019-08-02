using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> IsUpperCase = w => w[0] == w.ToUpper()[0];

            Console.WriteLine(
                String.Join($"{Environment.NewLine}",
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(IsUpperCase))
            ); 
        }
    }
}
