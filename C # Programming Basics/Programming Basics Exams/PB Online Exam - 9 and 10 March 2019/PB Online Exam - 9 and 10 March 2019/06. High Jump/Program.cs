using System;

namespace _06._High_Jump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetHigh = int.Parse(Console.ReadLine());
            int startingHih = targetHigh - 30;
            int counter = 0;
            int intend = 0;

            while (startingHih <= targetHigh)
            {


                for (int i = 0; i < 3; i++)
                {
                    intend = int.Parse(Console.ReadLine());
                    counter++;
                    if (intend > startingHih)
                    {

                        break;
                    }
                }
                if (intend <= startingHih)
                {
                    Console.WriteLine($"Tihomir failed at {startingHih}cm after {counter} jumps.");
                    return;
                }
                startingHih += 5;
            }
            Console.WriteLine($"Tihomir succeeded, he jumped over {targetHigh}cm after {counter} jumps.");
        }
    }
}
