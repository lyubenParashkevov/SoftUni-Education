

Queue<int> tools = new Queue<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> substances = new Stack<int>(Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

List<int> challenges = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

while (tools.Count > 0 && substances.Count > 0)
{
    int sum = tools.Peek() * substances.Peek();

    bool isTrue = true;

    for (int i = 0; i < challenges.Count; i++)
    {
        if (sum == challenges[i])
        {
            tools.Dequeue();
            substances.Pop();
            challenges.RemoveAt(i);
            i--;
            isTrue = false;
            break;
        }
    }
    if (isTrue)
    {
        int curTool = tools.Dequeue() + 1;
        tools.Enqueue(curTool);
        int curSubstance = substances.Pop() - 1;
        if (curSubstance > 0)
        {
            substances.Push(curSubstance);
        }
    }

    if (challenges.Count == 0)
    {
        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");

        if (tools.Count > 0)
        {
            Console.WriteLine($"Tools: {string.Join(", ", tools)}");
        }
        if (substances.Count > 0)
        {
            Console.WriteLine($"Substances: {string.Join(", ", substances)}");
        }
        return;
    }
}

Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");

if (tools.Count > 0)
{
    Console.WriteLine($"Tools: {string.Join(", ", tools)}");
}
if (substances.Count > 0)
{
    Console.WriteLine($"Substances: {string.Join(", ", substances)}");
}
if (challenges.Count > 0)
{
    Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
}
