using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Contracts
{
    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}
