using _8.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _8.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier // abstract, защото не инстанцираме никъде
    {
        public Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
        }
    }
}
