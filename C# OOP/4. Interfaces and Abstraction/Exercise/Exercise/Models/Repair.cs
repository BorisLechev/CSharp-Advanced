using Exercise.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Models
{
    public class Repair : IRepair
    {
        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
