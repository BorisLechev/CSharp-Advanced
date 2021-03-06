﻿using _8.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
            .AppendLine(base.ToString())
            .AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"  {mission.ToString().TrimEnd()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
