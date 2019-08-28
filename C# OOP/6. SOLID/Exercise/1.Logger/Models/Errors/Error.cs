using _1.Logger.Models.Contracts;
using _1.Logger.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Logger.Models.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level = Level.Info)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = Level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
