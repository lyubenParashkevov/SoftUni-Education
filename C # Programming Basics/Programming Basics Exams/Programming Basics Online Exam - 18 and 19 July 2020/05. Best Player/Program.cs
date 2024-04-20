using System;

namespace _05._Best_Player
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxGoals = int.MinValue;
            string bestPlayer = "";
            while (true)
            {
                string playerName = Console.ReadLine();
                if (playerName == "END")
                {
                    if (maxGoals >= 3)
                    {
                        Console.WriteLine($"{bestPlayer} is the best player!");
                        Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
                        break;
                    }
                    else
                    {

                        Console.WriteLine($"{bestPlayer} is the best player!");
                        Console.WriteLine($"He has scored {maxGoals} goals.");
                        break;
                    }
                }
                int goals = int.Parse(Console.ReadLine());
                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    bestPlayer = playerName;
                    if (maxGoals >= 10)
                    {
                        Console.WriteLine($"{bestPlayer} is the best player!");
                        Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
                        return;
                    }
                }

            }
        }
    }
}
