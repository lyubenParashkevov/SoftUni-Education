using System;

namespace _06._Barcode_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int firstA = firstNum / 1000;
            int firstB = (firstNum / 100) % 10;
            int firstC = (firstNum / 10)% 10;
            int firstD = firstNum % 10;

            int secA = secondNum / 1000;
            int secB = (secondNum / 100) % 10;
            int secC = (secondNum / 10)% 10;
            int secD = secondNum % 10;

                 for (int a = firstA; a <= secA; a++)
                 {
                     for (int b = firstB; b <= secB; b++)
                     {
                         for (int c = firstC; c <= secC; c++)
                         {
                             for (int d = firstD; d <= secD; d++)
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
}
