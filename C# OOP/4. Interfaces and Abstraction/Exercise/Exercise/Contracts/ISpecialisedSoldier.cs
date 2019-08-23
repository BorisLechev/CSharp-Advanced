using Exercise.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
