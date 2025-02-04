using System;
using GenericBoxofString;

Box<string> box = new Box<string>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    box.Add(input);
}

Console.WriteLine(box.ToString());
