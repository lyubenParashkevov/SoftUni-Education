using System;
using System.Numerics;

namespace _02.__Left_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string firstNum = "";
            string secondNum = "";
            long firstNumber = 0;
            long secondNumber = 0;
            long sumToPrint = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                for (int j = 0; j < input.Length; j++)
                {


                    if (input[j] != ' ')
                    {
                        secondNum += input[j];
                    }

                    else
                    {
                        firstNum = secondNum;
                        secondNum = "";
                    }
                }
                long biggerNumber = 0;
                firstNumber = long.Parse(firstNum);
                secondNumber = long.Parse(secondNum);
                firstNum = "";
                secondNum = "";
                if (firstNumber > secondNumber)
                {
                    biggerNumber = firstNumber;

                }
                else
                {
                    biggerNumber = secondNumber;
                }
                biggerNumber = Math.Abs(biggerNumber);
                while (biggerNumber > 0)
                {
                    sumToPrint += biggerNumber % 10;
                    biggerNumber /= 10;
                }
                Console.WriteLine(sumToPrint);
                firstNumber = 0;
                secondNumber = 0;
                sumToPrint = 0;
            }
        }
    }
}
