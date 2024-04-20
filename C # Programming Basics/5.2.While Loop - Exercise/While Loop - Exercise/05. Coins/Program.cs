using System;

namespace _05._Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double coinSum = change * 100;
            int count = 0;
            
            while (coinSum > 0)
            {
                if (coinSum >= 200)
                {
                    coinSum -= 200;
                }
                else if (coinSum >= 100)
                {
                    coinSum -= 100;
                }
                else if (coinSum >= 50)
                {
                    coinSum -=50;
                }
                else if (coinSum >= 20)
                {
                    coinSum -= 20;
                }
                else if (coinSum >= 10)
                {
                    coinSum -= 10;
                }
                else if (coinSum >= 5)
                {
                    coinSum -= 5;
                }
                else if (coinSum >= 2)
                {
                    coinSum -= 2;
                }
                else if (coinSum >= 1)
                {
                    coinSum -=1;
                }
                else
                {
                    break;
                }

                count++;

            }
            Console.WriteLine(count);
        }   
    }       
           
}           




