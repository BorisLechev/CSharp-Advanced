using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public class Validator
    {
        public static void ValidatePlayerName(string playerName)
        {
            if (string.IsNullOrEmpty(playerName) || string.IsNullOrWhiteSpace(playerName))
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }

        public static void ValidateCurrentSkillStatus(int skill, string skillName)
        {
            if (skill < 0 || skill > 100)
            {
                throw new ArgumentException($"{skillName} should be between 0 and 100.");
            }
        }

        public static void ValidateTeamName(string teamName)
        {
            if (string.IsNullOrEmpty(teamName) || string.IsNullOrWhiteSpace(teamName))
            {
                throw new ArgumentException("A name should not be empty.");
            }
        }

        public static void ValidateIfPlayerExist(List<Player> players, string playerName, string teamName)
        {
            if (!players.Any(x => x.Name == playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
            }
        }
    }
}
