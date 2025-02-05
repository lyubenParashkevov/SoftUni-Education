﻿using System;

namespace _01._Data_Type_F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int valueInt = 0;
            float valueFloat = 0.0f;
            char valueChar;
            bool valueBool;
            

            while (input != "END")
            {
                if (int.TryParse(input, out valueInt))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out valueFloat))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (Char.TryParse(input, out valueChar))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out valueBool))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
