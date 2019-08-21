using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Team
    {
        private string name;

        private double rating;

        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ValidateTeamName(value);
                this.name = value;
            }
        }

        public int Rating => CalculateRating();

        private int CalculateRating()
        {
            if (this.players.Count == 0)
            {
                return 0;
            }

            double rating = players.Select(x => x.GetAverageStatus()).Sum();

            return (int)Math.Round(rating);
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Validator.ValidateIfPlayerExist(this.players, name, this.Name);
            var player = this.players.Find(x => x.Name == name);
            this.players.Remove(player);
        }
    }
}
