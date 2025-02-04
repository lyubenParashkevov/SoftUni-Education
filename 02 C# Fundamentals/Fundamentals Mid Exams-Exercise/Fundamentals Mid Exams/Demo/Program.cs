List<int> houses = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
int failedHouses = 0;
int curindex = 0;
string input;
while ((input = Console.ReadLine()) != "Love!")
{
    string[] steps = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int step = int.Parse(steps[1]);

    curindex += step;
    if (curindex > houses.Count - 1)
    {
        curindex = 0;
    }
    if (houses[curindex] == 0)
    {
        Console.WriteLine($"Place 0 already had Valentine's day.");
    }
    else
    {
        houses[curindex] -= 2;
        if (houses[curindex] == 0)
        {
            Console.WriteLine($"Place {curindex} has Valentine's day.");
        }

    }

}

foreach (int i in houses)
{
    if (i != 0)
    {
        failedHouses++;
    }
}
if (failedHouses > 0)
{
    Console.WriteLine($"Cupid's last position was {curindex}.");
    Console.WriteLine($"Cupid has failed {failedHouses} places.");
}
else
{
    Console.WriteLine("Mission was successful.");
}