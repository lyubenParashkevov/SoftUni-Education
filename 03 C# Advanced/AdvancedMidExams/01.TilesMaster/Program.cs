

Stack<int> white = new Stack<int>(Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

Queue<int> grey = new Queue<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray());

Dictionary<string, int> locations = new Dictionary<string, int>
{
    { "Sink", 0 },
    { "Oven", 0 },
    { "Countertop", 0 },
    { "Wall", 0},
    { "Floor", 0 }
};

while (white.Count > 0 && grey.Count > 0)
{
    if (white.Peek() != grey.Peek())
    {
        int curWhite = white.Pop() / 2;
        white.Push(curWhite);
        int curGrey = grey.Dequeue();
        grey.Enqueue(curGrey);
        continue;
    }

    int sum = white.Pop() + grey.Dequeue();

    if (sum == 40)
    {
        locations["Sink"]++;
    }

    else if (sum == 50)
    {     
        locations["Oven"]++;
    }

    else if (sum == 60)
    {       
        locations["Countertop"]++;
    }

    else if (sum == 70)
    {      
        locations["Wall"]++;
    }

    else
    {
        locations["Floor"]++;
    }

}

if (white.Count > 0)
{
    Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
}
else
{
    Console.WriteLine("White tiles left: none");
}

if (grey.Count > 0)
{
    Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
}
else
{
    Console.WriteLine("Grey tiles left: none");
}

foreach (var item in locations.Where(i => i.Value > 0).OrderByDescending(i => i.Value).ThenBy(i => i.Key))
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}
        
