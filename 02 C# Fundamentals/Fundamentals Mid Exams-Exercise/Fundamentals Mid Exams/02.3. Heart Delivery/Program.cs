namespace _02._3._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int curStep = 0;
            int lastPlace = 0;
            int houseCounter = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Love!")
                {
                    break;
                }
                lastPlace = 0;
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                int jumpStep = int.Parse(commands[1]);
                curStep += jumpStep;

                if (curStep > neighborhood.Length - 1)
                {
                    curStep = 0;
                }
                for (int i = curStep; i < neighborhood.Length; i+= jumpStep)
                {        
                    lastPlace = i;
                    if (neighborhood[i] == 0)
                    {
                        Console.WriteLine($"Place {i} already had Valentine's day.");
                        break;
                    }
                    neighborhood[i] -= 2;
                    
                    if (neighborhood[i] == 0)
                    {                    
                        Console.WriteLine($"Place {i} has Valentine's day.");
                        break;
                    }

                    break;
                }
            }
            Console.WriteLine($"Cupid's last position was {lastPlace}.");

            for (int i = 0; i < neighborhood.Length; i++)
            {
                if (neighborhood[i] != 0)
                {
                    houseCounter++;
                }
            }

            if (houseCounter == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {houseCounter} places.");
            }

        }
    }
}