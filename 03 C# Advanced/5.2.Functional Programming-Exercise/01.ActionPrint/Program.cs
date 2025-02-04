



int[] startEndRange = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int start = startEndRange[0];
int end = startEndRange[1];

List<int> numbers = new List<int>();

string type  = Console.ReadLine();

for (int i = start; i <= end; i++)
{
    numbers.Add(i);
}

if (type == "even")
{
    Console.WriteLine(string.Join(" ",numbers.Where(n => n % 2 == 0)));
}

else
{
    Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));

}



