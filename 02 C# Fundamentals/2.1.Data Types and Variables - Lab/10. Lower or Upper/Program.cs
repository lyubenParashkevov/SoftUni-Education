﻿using System;

namespace _10._Lower_or_Upper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char ch = char.Parse(Console.ReadLine());
            if (Char.IsUpper(ch))
            {
                Console.WriteLine("upper-case");
            }
            else if (Char.IsLower(ch))
            {
                Console.WriteLine("lower-case");
            }



        }
    }
}
