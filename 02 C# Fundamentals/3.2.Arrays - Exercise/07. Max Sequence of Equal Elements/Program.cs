using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int tempCounter = 0;
            int counter = 0;
            int equalNums = 0;
            //string number = "";
            for (int i = 0; i < numbers.Length - 1; i++)
            {

                if (numbers[i] == numbers[i + 1])
                {
                    tempCounter++;

                    if (tempCounter > counter)
                    {
                        counter = tempCounter;
                        equalNums = numbers[i];
                        //number = numbers[i].ToString();
                    }
                }
                else
                {
                    tempCounter = 0;
                }

                
            }
            for (int j = 0; j <= counter; j++)
            {
                Console.Write($"{equalNums} ");
            }
        }
    }
}
