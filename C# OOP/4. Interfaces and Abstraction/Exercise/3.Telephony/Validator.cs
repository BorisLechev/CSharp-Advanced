using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Telephony
{
    public class Validator
    {
        public static string ValidateUrl(string url)
        {
            if (url.Any(s => char.IsDigit(s)))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public static string ValidatePhoneNumber(string number)
        {
            if (!number.All(char.IsDigit))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }
    }
}
