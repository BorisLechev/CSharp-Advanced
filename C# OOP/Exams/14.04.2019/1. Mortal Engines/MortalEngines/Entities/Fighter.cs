using MortalEngines.Entities.Contracts;
using MortalEngines.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HEALTH = 200;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, INITIAL_HEALTH)
        {
            this.ToggleAggressiveMode(); // za da setnem this.AgressMode = true
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;

                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }

            else
            {
                this.AggressiveMode = true;

                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            string aggressiveMode = this.AggressiveMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggressiveMode}";
        }
    }
}
