
using System.Runtime.InteropServices;
using System.Xml.Linq;

List<int> numbers = new();

string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < input.Length; i++)
{
    string item = input[i];

    try
    {
        int num = ValidateNum(item);
        numbers.Add(num);

    }
    catch (FormatException fEx)
    {
        Console.WriteLine(fEx.Message);
    }
    catch (OverflowException ovEx)
    {
        Console.WriteLine(ovEx.Message);
    }
    finally
    {
        Console.WriteLine($"Element '{item}' processed - current sum: {numbers.Sum()}");
    }
}

Console.WriteLine($"The total sum of all integers is: {numbers.Sum()}");

int ValidateNum(string item)
{
    if (!int.TryParse(item, out int numInt) && long.TryParse(item, out long numLong))
    {
        throw new OverflowException($"The element '{item}' is out of range!");

    }

    if (!int.TryParse(item, out numInt))
    {
        throw new FormatException($"The element '{item}' is in wrong format!");    
    }

    int number = int.Parse(item);
  
    return number;
}