

Dictionary<string, Dictionary<string, int>> players = new();

while (true)
{
    string input = Console.ReadLine();
    if (input == "Season end")
    {
        break;
    }

    

    if (input.Contains(" -> "))
    {
        string[] tokens = input.Split( " -> ", StringSplitOptions.RemoveEmptyEntries);
        string name = tokens[0];
        string position = tokens[1];
        int points = int.Parse(tokens[2]);

        if (!players.ContainsKey(name))
        {
            players.Add(name, new Dictionary<string, int>());
        }

        players[name].Add(position, points);
    }
    else
    {
        string[] tokens = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
        string firstPLayer = tokens[0];
        string secondPLayer = tokens[1];

        if (players.ContainsKey(firstPLayer) && players.ContainsKey(secondPLayer))
        {
            foreach (var p in players[firstPLayer].Keys)
            {
                foreach (var a in players[secondPLayer].Keys)
                {
                    if (a == p)
                    {
                        if (players[firstPLayer][p] > players[secondPLayer][a])
                        {
                            players.Remove(secondPLayer);

                        }
                        else if (players[firstPLayer][p] < players[secondPLayer][a])
                        {
                            players.Remove(firstPLayer);
                        }
                        else 
                        {
                            continue;
                        }

                    }
                }
            }
        }
    }
}

foreach (var p in players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
{
    Console.WriteLine($"{p.Key}: {p.Value.Values.Sum()} skill");
    foreach (var x in p.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
    {
        Console.WriteLine($"- {x.Key} <::> {x.Value}");
    }
}