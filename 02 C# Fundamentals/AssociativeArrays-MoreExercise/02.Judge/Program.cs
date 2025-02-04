using System.Collections.Specialized;

Dictionary<string, string> contests = new();
Dictionary<string, Dictionary<string, int>> students = new();

while (true)
{
    string input = Console.ReadLine();
    if (input == "end of contests")
    {
        break;
    }
    string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
    string contest = tokens[0];
    string password = tokens[1];

    contests.Add(contest, password);

}

while (true)
{
    string secInput = Console.ReadLine();
    if (secInput == "end of submissions")
    {
        break;
    }

    string[] secTokens = secInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
    string newContest = secTokens[0];
    string newPassword = secTokens[1];
    string user = secTokens[2];
    int points = int.Parse(secTokens[3]);

    if (!contests.ContainsKey(newContest) || contests[newContest] != newPassword)
    {
        continue;
    }
     
    if (!students.ContainsKey(user))
    {
        students.Add(user, new Dictionary<string, int>());
    }

    if (students[user].ContainsKey(newContest))
    {
        if (students[user][newContest] < points)
        {
            students[user][newContest] = points;
        }
    }
    else
    {
        students[user].Add(newContest, points);

    }

}

string winner = students.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
int maxPoints = students.OrderByDescending(x => x.Value.Values.Sum()).First().Value.Values.Sum();

Console.WriteLine($"Best candidate is {winner} with total {maxPoints} points.");
Console.WriteLine("Ranking:");

foreach (var stud in students.OrderBy(x => x.Key))
{
    Console.WriteLine(stud.Key);
    foreach (var val in stud.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {val.Key} -> {val.Value}");
    }
}





