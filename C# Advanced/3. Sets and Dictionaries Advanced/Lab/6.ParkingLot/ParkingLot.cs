using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ParkingLot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> hashSet = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "IN")
                {
                    hashSet.Add(tokens[1]);
                }

                else if (tokens[0] == "OUT")
                {
                    hashSet.Remove(tokens[1]);
                }
            }

            if (hashSet.Count > 0)
            {
                foreach (var item in hashSet)
                {
                    Console.WriteLine(item);
                }
            }

            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}