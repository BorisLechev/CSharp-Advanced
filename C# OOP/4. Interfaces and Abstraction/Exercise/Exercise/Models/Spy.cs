using Exercise.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName) 
            : base(id, firstName, lastName)
        {
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Code Number: {this.CodeNumber}";
        }
    }
}
