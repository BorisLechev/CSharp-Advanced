using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Logger.Models.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
