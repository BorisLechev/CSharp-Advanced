using System;
using System.Collections.Generic;
using System.Text;

namespace _9.CollectionHierarchy.Contracts
{
    public interface IAddableAndRemovable : IAddable
    {
        string Remove();
    }
}
