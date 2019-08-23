using Exercise.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
