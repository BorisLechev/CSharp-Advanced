using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces.Contracts
{
    public interface IResident : IPerson
    {
        int Age { get; }

        string GetName();
    }
}
