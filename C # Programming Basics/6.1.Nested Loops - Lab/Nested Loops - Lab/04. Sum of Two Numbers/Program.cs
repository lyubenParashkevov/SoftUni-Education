using System;

namespace _04._Sum_of_Two_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int combiCounter = 0;
            for (int i = firstNum; i <= secondNum; i++)
            {
                    

                for (int j = firstNum; j <= secondNum; j++)
                {
                    combiCounter++;

                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combiCounter} ({i} + {j} = {magicNum})");
                        return;
                    }

                }

            }
            Console.WriteLine($"{combiCounter} combinations - neither equals {magicNum}");







        }
    }
}
