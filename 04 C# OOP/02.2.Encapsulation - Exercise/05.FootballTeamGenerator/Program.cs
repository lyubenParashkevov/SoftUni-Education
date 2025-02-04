

using _05.FootballTeamGenerator.Models;
using System.Numerics;

List<Team> teams = new List<Team>();

string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] commandInfo = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string command = commandInfo[0];

    try
    {
        if (command == "Team")
        {
            AddTeam(commandInfo[1], teams);
        }

        else if (command == "Add")
        {
            AddPlayer(commandInfo[1], commandInfo[2], int.Parse(commandInfo[3]), int.Parse(commandInfo[4]),
                        int.Parse(commandInfo[5]), int.Parse(commandInfo[6]), int.Parse(commandInfo[7]), teams);
        }

        else if (command == "Remove")
        {
            RemovePlayer(commandInfo[1], commandInfo[2],teams);
        }

        else if (command == "Rating")
        {
            PrintRating(commandInfo[1], teams);
        }
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
    
}

static void AddTeam(string name, List<Team> teams)
{
    teams.Add(new Team(name));
}

static void AddPlayer(
    string teamName,
    string name,
    int endurance,
    int sprint,
    int dribble,
    int passing,
    int shooting,
    List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException($"Team {teamName} does not exist.");
    }

    Player player = new(name, endurance, sprint, dribble, passing, shooting);
    team.AddPlayer(player);
}

static void RemovePlayer(string teamName, string playerName, List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException($"Team {teamName} does not exist.");
    }

    team.RemovePlayer(playerName);
}

static void PrintRating(string teamName, List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException($"Team {teamName} does not exist.");
    }

    Console.WriteLine($"{teamName} - {team.Rating:f0}");
}

