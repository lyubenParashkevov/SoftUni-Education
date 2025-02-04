namespace _02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            int roomCounter = 0;
            string[] rooms = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] action = rooms[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                roomCounter++;
                int healOrBitcoin = int.Parse(action[1]);

                if (action[0] == "potion")
                {
                    if (health + healOrBitcoin > 100)
                    {
                        healOrBitcoin = 100 - health;
                    }
                    health += healOrBitcoin;
                   // if (health > 100)
                   // {
                   //     health = 100;
                   // }

                    Console.WriteLine($"You healed for {healOrBitcoin} hp.");
                    Console.WriteLine($"Current health: {health} hp.");

                }
                else if (action[0] == "chest")
                {
                    bitcoins += healOrBitcoin;
                    Console.WriteLine($"You found {healOrBitcoin} bitcoins.");
                }
                else
                {
                    health -= healOrBitcoin;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {action[0]}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {action[0]}.");
                        Console.WriteLine($"Best room: {roomCounter}");
                        return;
                    }
                }

            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}