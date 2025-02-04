

Stack<int> food = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Queue<int> stamina = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

List<string> mountains = new List<string>()
{
    "Vihren",
    "Kutelo",
    "Banski Suhodol",
    "Polezhan",
    "Kamenitza"
};

List<int> mountainValue = new List<int>()
{
    80,
    90,
    100,
    60,
    70
};

List<string> conqueredMountains = new List<string>();

while (stamina.Count > 0 && mountains.Count > 0)
{
    int sum = food.Pop() + stamina.Dequeue();

    if (sum >= mountainValue[0])
    {
        mountainValue.RemoveAt(0);
        conqueredMountains.Add(mountains[0]);
        mountains.RemoveAt(0);
    }

}

if (stamina.Count == 0 && conqueredMountains.Count < 5)
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
    if (conqueredMountains.Any())
    {
        Console.WriteLine("Conquered peaks:");
        foreach (var con in conqueredMountains)
        {
            Console.WriteLine(con);
        }
    }
}
else
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
    Console.WriteLine("Conquered peaks:");
    foreach (var con in conqueredMountains)
    {
        Console.WriteLine(con);
    }
}