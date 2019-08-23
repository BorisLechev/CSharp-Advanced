using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string EXC_MESSAGE = "Invalid state!";

        public InvalidStateException()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidStateException(string message)
            : base(message)
        {
        }
    }
}
