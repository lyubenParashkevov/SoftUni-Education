﻿using BoxOfString;
using System;

int n = int.Parse(Console.ReadLine());

Box<int> box = new Box<int>();

for (int i = 0; i < n; i++)
{
    int input = int.Parse(Console.ReadLine());

    box.Add(input);
}

Console.WriteLine(box.ToString());