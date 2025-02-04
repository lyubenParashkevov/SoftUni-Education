using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Problem05TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] creatorAntTeam = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                string creator = creatorAntTeam[0];
                string teamName = creatorAntTeam[1];

                if (teams.Any(t => t.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(t => t.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team(creator, teamName, new List<string>());
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            while (true)
            {
                string[] membersToAdd = Console.ReadLine().Split("->");
                {
                    if (membersToAdd[0] == "end of assignment")
                    {
                        break;
                    }

                    string member = membersToAdd[0];
                    string teamName = membersToAdd[1];

                    if (!teams.Any(t => t.TeamName == teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist!");
                        continue;
                    }

                    foreach (Team team in teams.Where(t => t.TeamName == teamName))
                    {
                        if (team.Members.Contains(member) || team.Creator == member)
                        {
                            Console.WriteLine($"Member {member} cannot join team {teamName}!");
                        }

                        else
                        {
                            team.Members.Add(member);
                        }
                    }
                }
            }

            List<Team> teamsToDisband = new List<Team>();

            for (int i = 0; i < teams.Count; i++) 
            {
                if (teams[i].Members.Count == 0)
                {
                    teamsToDisband.Add(teams[i]);
                    teams.RemoveAt(i);
                    i--;
                }
            }
            teams = teams.OrderByDescending(t => t.Members.Count).ThenBy(t => t.TeamName).ToList();           

            foreach (Team team in teams)
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            if (teamsToDisband.Count > 0)
            {
                teamsToDisband = teamsToDisband.OrderBy(x => x.TeamName).ToList();
                foreach (var item in teamsToDisband)
                {
                    Console.WriteLine(item.TeamName);
                }
            }
        }
    }

    public class Team
    {
        public Team(string creator, string teamName, List<string> members)
        {
            Creator = creator;
            TeamName = teamName;
            Members = new List<string>();
        }

        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }
    }
}