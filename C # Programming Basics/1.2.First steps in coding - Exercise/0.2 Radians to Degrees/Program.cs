﻿using System;

namespace _0._2_Radians_to_Degrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());
            double degrees = radians * 180/Math.PI;
            Console.WriteLine(degrees); 
        }
    }
}
