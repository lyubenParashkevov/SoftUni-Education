

using System;

Queue<int> coffee = new Queue<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> milk = new Stack<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<string, int> drinks = new Dictionary<string, int>
{
    { "Cortado", 0 },  // 50
    { "Espresso", 0 },  // 75
    { "Capuccino", 0 }, // 100
    { "Americano", 0 }, // 150
    { "Latte", 0 }      // 200
};

while (coffee.Count > 0 && milk.Count > 0)
{

    int sum = coffee.Peek() + milk.Peek();

    if (sum == 50)
    {
        coffee.Dequeue();
        milk.Pop();
        drinks["Cortado"]++;
    }

    else if (sum == 75)
    {
        coffee.Dequeue();
        milk.Pop();
        drinks["Espresso"]++;
    }

    else if (sum == 100)
    {
        coffee.Dequeue();
        milk.Pop();
        drinks["Capuccino"]++;
    }

    else if (sum == 150)
    {
        coffee.Dequeue();
        milk.Pop();
        drinks["Americano"]++;
    }

    else if (sum == 200)
    {
        coffee.Dequeue();
        milk.Pop();
        drinks["Latte"]++;
    }

    else
    {
        coffee.Dequeue();
        int curMilk = milk.Pop() - 5;
        milk.Push(curMilk);
    }
}

if (coffee.Count == 0 && milk.Count == 0)
{
    Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
}
else
{
    Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
}

if (coffee.Count == 0)
{
    Console.WriteLine("Coffee left: none");
}
else
{
    Console.WriteLine($"Coffee left: {string.Join(", ",coffee)}");
}

if (milk.Count == 0)
{
    Console.WriteLine("Milk left: none");
}
else
{
    Console.WriteLine($"Milk left: {string.Join(", ",milk)}");
}

foreach (var drink in drinks.Where(d => d.Value > 0).OrderBy(d => d.Value).ThenByDescending(d => d.Key))
{
    Console.WriteLine($"{drink.Key}: {drink.Value}");
}