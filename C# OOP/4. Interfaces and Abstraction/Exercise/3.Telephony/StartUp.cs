using _3.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> phoneNumbers =
                Console.ReadLine()
                .Split()
                .ToList();

            List<string> urls =
                Console.ReadLine()
                .Split()
                .ToList();

            ICallable smartphoneCall = new Smartphone();

            phoneNumbers
                .ForEach(p => Console.WriteLine(smartphoneCall.Call(p)));

            IBrowsable smartphoneBrowse = new Smartphone();

            urls
                .ForEach(u => Console.WriteLine(smartphoneBrowse.Browse(u)));
        }
    }
}
