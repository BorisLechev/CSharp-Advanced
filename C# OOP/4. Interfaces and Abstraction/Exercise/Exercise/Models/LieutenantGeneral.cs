using Exercise.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<ISoldier> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => this.privates;

        public void AddSoldier(ISoldier @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (ISoldier pr in this.privates)
            {
                sb
                    .AppendLine($"{pr.ToString()}");
            }

            return sb.ToString();
        }
    }
}
