using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Contracts
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
