using _1.Logger.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Logger.Models.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
