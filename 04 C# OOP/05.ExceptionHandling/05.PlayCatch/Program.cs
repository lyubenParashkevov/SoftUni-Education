
using System;
using System.Reflection;

int exceptionCount = 0;
List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
string[] tokens;
int first;
int second;
while (exceptionCount < 3)
{
    tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];
    string index1 = tokens[1];


    try
    {
        if (command == "Replace")
        {
            string index2 = tokens[2];
            first = ValidateFirstIndex(index1);
            second = ValidateSecondIndex(index2);
            ValidateFirstIndexRange();

            numbers[first] = second;
        }
        else if (command == "Print")
        {
            int curIndex = 0;
            string index2 = tokens[2];
            first = ValidateFirstIndex(index1);
            second = ValidateSecondIndex(index2);
            ValidateFirstIndexRange();
            ValidateSecondIndexRange();

            for (int i = first; i < second; i++)
            {
                curIndex = i;
                Console.Write(numbers[i] + ", ");
            }
            Console.Write(numbers[curIndex + 1]);
            Console.WriteLine();
        }
        else if (command == "Show")
        {
            first = ValidateFirstIndex(index1);
            ValidateFirstIndexRange();

            Console.WriteLine(numbers[first]);
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(", ", numbers));

int ValidateFirstIndex(string index)
{
    if (!int.TryParse(tokens[1], out int element1))
    {
        exceptionCount++;
        throw new ArgumentException("The variable is not in the correct format!");
    }
    return element1;
}

int ValidateSecondIndex(string index2)
{
    if (!int.TryParse(index2, out int element2))
    {
        exceptionCount++;
        throw new ArgumentException("The variable is not in the correct format!");
    }
    return element2;
}

void ValidateFirstIndexRange()
{
    if (first < 0 || first >= numbers.Count)
    {
        exceptionCount++;
        throw new ArgumentException("The index does not exist!");
    }
}

void ValidateSecondIndexRange()
{
    if (second < 0 || second >= numbers.Count)
    {
        exceptionCount++;
        throw new ArgumentException("The index does not exist!");
    }
}


