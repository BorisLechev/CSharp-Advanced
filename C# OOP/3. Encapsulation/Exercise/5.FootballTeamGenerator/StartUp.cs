using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main()
        {
            List<Team> teams = new List<Team>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitedInput = input.Split(';');

                string command = splitedInput[0];
                string teamName = splitedInput[1];

                if (command == "Team")
                {
                    try
                    {
                        teams.Add(new Team(teamName));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }

                else
                {
                    if (!teams.Any(x => x.Name == teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    Team team = teams.Find(x => x.Name == teamName);

                    switch (command)
                    {
                        case "Add":
                            string playerName = splitedInput[2];
                            int endurance = int.Parse(splitedInput[3]);
                            int sprint = int.Parse(splitedInput[4]);
                            int dribble = int.Parse(splitedInput[5]);
                            int passing = int.Parse(splitedInput[6]);
                            int shooting = int.Parse(splitedInput[7]);

                            try
                            {
                                SkillStatus stats = new SkillStatus(endurance, sprint, dribble, passing, shooting);
                                Player player = new Player(playerName, stats);

                                team.AddPlayer(player);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;

                        case "Remove":

                            string nameOfPlayer = splitedInput[2];

                            try
                            {
                                team.RemovePlayer(nameOfPlayer);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;

                        case "Rating":
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                            break;
                    }
                }
            }
        }
    }
}
