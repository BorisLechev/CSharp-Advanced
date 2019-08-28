using _1.Logger.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}
