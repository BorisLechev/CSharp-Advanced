using _8.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hourseWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hourseWorked;
        }

        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
