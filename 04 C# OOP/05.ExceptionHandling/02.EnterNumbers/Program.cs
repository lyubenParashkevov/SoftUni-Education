





int end = 100;
int start = 1;
List<int> numbers = new();

while (numbers.Count < 10)
{
    try
    {
        int number = ReadNumber(start, end);
        numbers.Add(number);
        start = number;
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message); ;
    }

    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine($"Your number is not in range {start} - 100!");
    }

}

Console.WriteLine(string.Join(", ", numbers));

int ReadNumber(int start, int end)
{
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int number))
    {
        throw new FormatException("Invalid Number!");

    }

    if (number < start + 1 || number > end - 1)
    {
        throw new ArgumentOutOfRangeException();
    }

    return number;
}
