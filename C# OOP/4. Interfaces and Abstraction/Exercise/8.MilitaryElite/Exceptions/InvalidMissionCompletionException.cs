using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string EXC_MESSAGE = "You cannot finish already completed mission.";

        public InvalidMissionCompletionException()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidMissionCompletionException(string message) 
            : base(message)
        {
        }
    }
}
