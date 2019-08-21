using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name, SkillStatus status)
        {
            this.Name = name;
            this.Stats = status;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidatePlayerName(value);
                this.name = value;
            }
        }

        public SkillStatus Stats { get; set; }

        public double GetAverageStatus()
        {
            var stats = new List<int>() { this.Stats.Endurance
                , this.Stats.Sprint
                , this.Stats.Dribble
                , this.Stats.Passing
                , this.Stats.Shooting };

            double avarage = stats.Average();

            return avarage;
        }
    }
}
