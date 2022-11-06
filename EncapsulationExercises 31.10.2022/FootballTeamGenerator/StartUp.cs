using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string[] cmdArg = Console.ReadLine().Split(";");

            while (cmdArg[0] != "END")
            {
                string command = cmdArg[0];
                string teamName = cmdArg[1];
                string playerName = string.Empty;
                int endurance = -1;
                int sprint = -1;
                int dribble = -1;
                int passing = -1;
                int shooting = -1;

                try
                {
                    switch (command)
                    {
                        case "Team":
                            Team team = new Team(teamName);
                            teams.Add(team);
                            break;

                        case "Add":
                            if (!teams.Any(t => t.Name == teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            playerName = cmdArg[2];
                            endurance = int.Parse(cmdArg[3]);
                            sprint = int.Parse(cmdArg[4]);
                            dribble = int.Parse(cmdArg[5]);
                            passing = int.Parse(cmdArg[6]);
                            shooting = int.Parse(cmdArg[7]);
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams.First(t => t.Name == teamName).AddPlayer(player);
                            break;

                        case "Remove":
                            if (!teams.Any(t => t.Name == teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            playerName = cmdArg[2];
                            teams.First(t => t.Name == teamName).RemovePlayer(playerName);
                            break;

                        case "Rating":
                            if (!teams.Any(t => t.Name == teamName))
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                            Console.WriteLine(teams.First(t => t.Name == teamName));
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                cmdArg = Console.ReadLine().Split(";");
            }
        }
    }
}
