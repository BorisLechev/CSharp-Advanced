using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Contracts
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
