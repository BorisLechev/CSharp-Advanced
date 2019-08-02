using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int numberOfUsernames = int.Parse(Console.ReadLine());
            HashSet<string> hashSet = new HashSet<string>();

            for (int i = 0; i < numberOfUsernames; i++)
            {
                hashSet.Add(Console.ReadLine());
            }

            foreach (var username in hashSet)
            {
                Console.WriteLine(username);
            }
        }
    }
}
