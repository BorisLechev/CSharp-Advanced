using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        string Name { get; }

        int Age { get; }

        string Country { get; }

        string GetName();
    }
}
