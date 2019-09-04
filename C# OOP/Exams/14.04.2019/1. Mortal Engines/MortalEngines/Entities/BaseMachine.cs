namespace MortalEngines.Models
{
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseMachine : IMachine
    {
        private string name;

        private IPilot pilot;

        private IList<string> targets;

        private BaseMachine()
        {
            this.targets = new List<string>();
        }

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
            : this()
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ThrowIfNameIsNull(value, ExceptionMessages.INVALID_BASE_MACHINE_NAME);

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.INVALID_PILOT);
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                Validator.ThrowIfMachineIsNull(target, ExceptionMessages.INVALID_TARGET);
            }

            double healthPointsDecreasement = this.AttackPoints - target.DefensePoints;
            target.HealthPoints -= healthPointsDecreasement;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string targetResult = this.targets.Count > 0 ? string.Join(",", this.targets) : "None" ;

            sb
                .AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:f2}")
                .AppendLine($" *Attack: {this.AttackPoints:f2}")
                .AppendLine($" *Defense: {this.DefensePoints:f2}")
                .AppendLine($" *Targets: – {targetResult}");

            return sb.ToString().TrimEnd();
        }
    }
}
