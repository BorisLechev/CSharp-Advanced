using System;
using _1.Logger.Models.Enumerators;

namespace _1.Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
