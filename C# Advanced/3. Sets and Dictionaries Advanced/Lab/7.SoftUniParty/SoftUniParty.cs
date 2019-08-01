using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> reservations = new HashSet<string>();
            HashSet<string> vipReservations = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                if (input.Length == 8)
                {
                    if (char.IsDigit(input[0]))
                    {
                        vipReservations.Add(input);
                    }

                    else
                    {
                        reservations.Add(input);
                    }
                }

                else if (input == "PARTY")
                {
                    break;
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (reservations.Contains(input))
                {
                    reservations.Remove(input);
                }

                else if (vipReservations.Contains(input))
                {
                    vipReservations.Remove(input);
                }
            }

            Console.WriteLine(reservations.Count + vipReservations.Count);

            if (vipReservations.Count > 0)
            {
                Console.WriteLine(string.Join($"{Environment.NewLine}", vipReservations));
            }

            if (reservations.Count > 0)
            {
                Console.WriteLine(string.Join($"{Environment.NewLine}", reservations));
            }
        }
    }
}
