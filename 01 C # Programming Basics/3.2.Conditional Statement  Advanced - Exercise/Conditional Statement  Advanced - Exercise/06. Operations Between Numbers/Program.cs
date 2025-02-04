using System;

namespace _06._Operations_Between_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //(+) (-) (*) отпечатваме резултата и дали е четен или неетен
            //  при (/) - резултата ( на 0 не се дели)        при (%) - остатъка

            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double result = 0;

            if (operation == '+')
            {
                result = n1 + n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} + {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} + {n2} = {result} - odd");
                }

            }
            else if (operation == '-')
            {
                result = n1 - n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} - {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} - {n2} = {result} - odd");
                }
            }
            else if (operation == '*')
            {
                result = n1 * n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} * {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} * {n2} = {result} - odd");
                }
            }
            else if (operation == '/')
            {
                result = (double)n1 / n2;

                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{(double)n1} / {n2} = {result:f2}");
                }
            }
            else if (operation == '%')
            {
               

                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    result = n1 % n2;
                Console.WriteLine($"{n1} % {n2} = {result}");
                }
            }
        }
    }
}
