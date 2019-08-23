using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string EXC_MESSAGE = "Invalid corps!";

        public InvalidCorpsException()
        {
        }

        public InvalidCorpsException(string message) 
            : base(EXC_MESSAGE)
        {
        }
    }
}
