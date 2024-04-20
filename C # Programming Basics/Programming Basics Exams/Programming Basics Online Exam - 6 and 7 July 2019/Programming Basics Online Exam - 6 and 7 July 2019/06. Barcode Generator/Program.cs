using System;

namespace _06._Barcode_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            


                for (int a = 1; a <= 9; a++)
                
                   for (int b = 1; b <= 9; b++)
                   {
                       for (int c = 1; c <= 9; c++)
                       {
                           for (int d = 1; d <= 9; d++)
                           {
                               
                               
                
                                   if (a % 2 != 0 && b % 2 != 0 && c % 2 != 0 && d % 2 != 0)
                                   {
                                       Console.Write($"{a}{b}{c}{d} ");
                                   }
                               
                           }
                       }
                   }
            
                

        }
    }
}
