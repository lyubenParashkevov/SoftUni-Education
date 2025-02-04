
Dictionary<string, Dictionary<string, int>> contests = new();
Dictionary<string, int> users = new();

while (true)
{
    string input = Console.ReadLine();

    if (input == "no more time") { break; }

    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

    string user = tokens[0];
    string contest = tokens[1];
    int points = int.Parse(tokens[2]);

    if (!contests.ContainsKey(contest))
    {
        contests.Add(contest, new Dictionary<string, int>());
    }

    if (!contests[contest].Keys.Contains(user))
    {
        contests[contest].Add(user, points);
    }

    if (contests[contest][user] < points)
    {
        contests[contest][user] = points;
    }
}

int counter = 0;
foreach (var contest in contests)
{
    Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");

    foreach (var c in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
    {
        counter++;

        Console.WriteLine($"{counter}. {c.Key} <::> {c.Value}");
    }
    counter = 0;
}

Console.WriteLine("Individual standings:");


foreach (var contest in contests)
{
    foreach (var c in contest.Value)
    {
        if (!users.ContainsKey(c.Key))
        {
            users.Add(c.Key, 0);
        }
        users[c.Key] += c.Value;

    }
}

int position = 0;
foreach (var u in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    position++;
    Console.WriteLine($"{position}. {u.Key} -> {u.Value}");
}