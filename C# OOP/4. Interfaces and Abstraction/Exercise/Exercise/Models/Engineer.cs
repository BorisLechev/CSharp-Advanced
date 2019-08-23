using Exercise.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs = new List<IRepair>();

        public Engineer(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (IRepair repair in this.repairs)
            {
                sb
                    .AppendLine($"{repair.ToString()}");
            }

            return sb.ToString();
        }
    }
}
