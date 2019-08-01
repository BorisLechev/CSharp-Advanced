using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.RecordUniqueNames
{
    class RecordUniqueNames
    {
        static void Main(string[] args)
        {
            int countOfNames = int.Parse(Console.ReadLine());
            HashSet<string> hashSet = new HashSet<string>();

            for (int i = 0; i < countOfNames; i++)
            {
                string name = Console.ReadLine();

                hashSet.Add(name);
            }

            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}