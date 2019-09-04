using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Common
{
    public class Validator
    {
        public static void ThrowIfNameIsNull(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ThrowIfMachineIsNull(IMachine machine, string message)
        {
            throw new NullReferenceException(message);
        }
    }
}
