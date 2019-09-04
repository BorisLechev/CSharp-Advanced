using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;

        private IList<IMachine> machines;

        private Pilot()
        {
            this.machines = new List<IMachine>();
        }

        public Pilot(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ThrowIfNameIsNull(value, ExceptionMessages.INVALID_PILOT_NAME);

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                Validator.ThrowIfMachineIsNull(machine, ExceptionMessages.INVALID_PILOT_MACHINE);
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (IMachine machine in this.machines)
            {
                sb
                    .AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
