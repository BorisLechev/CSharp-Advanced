using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Contracts
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
