using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public int Count => this.data.Count;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Astronaut astronaut)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            foreach (Astronaut astronaut in data)
            {
                if (astronaut.Name == name)
                {
                    data.Remove(astronaut);
                    return true;
                }
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            return this.data
                .OrderByDescending(a => a.Age)
                .FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data
                .FirstOrDefault(a => a.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (Astronaut astronaut in this.data)
            {
                sb.AppendLine($"{astronaut}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
