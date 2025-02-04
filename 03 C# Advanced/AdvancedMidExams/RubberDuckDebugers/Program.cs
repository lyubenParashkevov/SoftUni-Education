

int[] numsToQueue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[] numsToStack = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Queue<int> queueTime = new Queue<int>();

Stack<int> stackTasks = new Stack<int>();

Dictionary<string, int> ducks = new Dictionary<string, int>(4)
{
    { "Darth Vader Ducky", 0 },
    { "Thor Ducky", 0 },
    { "Big Blue Rubber Ducky", 0 },
    { "Small Yellow Rubber Ducky", 0 }
};


for (int i = 0; i < numsToQueue.Length; i++)
{
    queueTime.Enqueue(numsToQueue[i]);
}

for (int i = 0; i < numsToStack.Length; i++)
{
    stackTasks.Push(numsToStack[i]);
}

int sum = 0;

while (stackTasks.Count > 0)
{
    int curTime = queueTime.Dequeue();
    int curTask = stackTasks.Pop();

    if (curTime * curTask > 240)
    {
        queueTime.Enqueue(curTime);
        curTask -= 2;
        stackTasks.Push(curTask);
    }

    else if (curTime * curTask <= 60)
    {
        ducks["Darth Vader Ducky"]++;
    }

    else if (curTime * curTask <= 120)
    {
        ducks["Thor Ducky"]++;
    }

    else if (curTime * curTask <= 180)
    {
        ducks["Big Blue Rubber Ducky"]++;
    }

    else if (curTime * curTask <= 240)
    {
        ducks["Small Yellow Rubber Ducky"]++;
    }
}

Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

foreach (var duck in ducks)
{
    Console.WriteLine($"{duck.Key}: {duck.Value}");
}