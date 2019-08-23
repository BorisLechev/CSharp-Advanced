using _3.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            return Validator.ValidateUrl(url);
        }

        public string Call(string number)
        {
            return Validator.ValidatePhoneNumber(number);
        }
    }
}
