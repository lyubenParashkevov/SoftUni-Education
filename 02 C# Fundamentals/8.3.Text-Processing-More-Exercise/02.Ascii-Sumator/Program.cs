
char first = char.Parse(Console.ReadLine());
char second = char.Parse(Console.ReadLine());
string input = Console.ReadLine();

int sum = 0;  

foreach (char ch in input)
{
    if (ch > first && ch < second)
    {
        sum += ch;
    }
}
Console.WriteLine(sum);