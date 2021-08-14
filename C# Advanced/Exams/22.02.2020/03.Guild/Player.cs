using System.Text;

namespace _03.Guild
{
    public class Player
    {
        public Player(string name, string currClass)
        {
            this.Name = name;
            this.Class = currClass;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
