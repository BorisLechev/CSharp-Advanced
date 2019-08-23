using _8.MilitaryElite.Contracts;
using _8.MilitaryElite.Enumerations;
using _8.MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps); // като int.TryParse

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
