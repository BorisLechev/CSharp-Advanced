using Exercise.Contracts;
using Exercise.Enumerators;
using Exercise.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorpse(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorpse(string corpsStr)
        {
            Corps corps;

            bool isParsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!isParsed)
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
