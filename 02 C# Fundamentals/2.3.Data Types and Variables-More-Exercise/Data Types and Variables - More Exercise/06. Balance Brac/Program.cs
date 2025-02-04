using System;

namespace _06._Balance_Brac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                int leftBracketsCounter = 0;
                int rightBracketsCounter = 0;

            for (int i = 0; i < n; i++)
            {

                string input = Console.ReadLine();
                

                if (input == "(")
                {
                    
                    leftBracketsCounter++;
                }
                else if (input == ")")
                {
                    
                    rightBracketsCounter++;
                }
                if (rightBracketsCounter > leftBracketsCounter)
                {
                    Console.WriteLine("UNBALANCED");
                    return;
                }
                
            }
            if (leftBracketsCounter == rightBracketsCounter)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
