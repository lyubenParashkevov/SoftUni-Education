using System;

namespace _04._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;
            
            string input = "";
            while ((input = Console.ReadLine()) != "Going home")
            {
                int eachTimeSteps = int.Parse(input);
                steps += eachTimeSteps;

                if (steps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{steps - 10000} steps over the goal!");
                    {
                        return;
                    }
                }                 
                                 
            }
            int lastSteps = int.Parse(Console.ReadLine());
            steps += lastSteps;
            if (steps < 10000)
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");

            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - 10000} steps over the goal!");

            }
        }
    }
}
