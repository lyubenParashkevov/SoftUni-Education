using System;

namespace _04._Game_Number_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
             string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string input = "";
            int card1 = 0;
            int card2 = 0;
            int points1 = 0;
            int point2 = 0;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "End of game")
                {
                    Console.WriteLine($"{firstName} has {points1} points");
                    Console.WriteLine($"{secondName} has {point2} points");
                    break;
                }
                card1 = int.Parse(input);
                input = Console.ReadLine();
                card2 = int.Parse(input);
                if (card1 > card2)
                {
                    points1 += card1 - card2;
                }
                else if (card1 < card2)
                {
                    point2 += card2 - card1;
                }
                else
                {
                    input = Console.ReadLine();
                    card1 = int.Parse(input);
                    input = Console.ReadLine();
                    card2 = int.Parse(input);
                    if (card1 > point2)
                    {
                        Console.WriteLine("Number wars!");
                        Console.WriteLine($"{firstName} is winner with {points1} points");
                    }
                    else if (card1 < point2)
                    {
                        Console.WriteLine("Number wars!");
                        Console.WriteLine($"{secondName} is winner with {point2} points");
                    }
                    return;
                   
                }
            }
        }
    }
}
