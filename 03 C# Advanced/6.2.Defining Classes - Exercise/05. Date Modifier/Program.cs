﻿

namespace DefiningClasses;
public class StartUp
{
    static void Main(string[] args)
    {
        string start = Console.ReadLine();
        string end = Console.ReadLine();

        int differenceInDays = DateModifier.GetDifferenceInDays(start, end);

        Console.WriteLine(differenceInDays);
    }

}