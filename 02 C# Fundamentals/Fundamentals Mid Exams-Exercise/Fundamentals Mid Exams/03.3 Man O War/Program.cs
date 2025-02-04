namespace _03._3_Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Retire")
                {
                    break;
                }

                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string comand = commands[0];

                if (comand == "Fire")
                {
                    int index = int.Parse(commands[1]);
                    int damage = int.Parse(commands[2]);

                    if (index < 0 || index > warShip.Count - 1)
                    {
                        continue;
                    }
                    warShip[index] -= damage;
                    if (warShip[index] <= 0)
                    {
                        Console.WriteLine("You won! The enemy ship has sunken.");
                        return;
                    }
                }
                else if (comand == "Defend")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    int damage = int.Parse(commands[3]);

                    if (startIndex < 0 || startIndex > endIndex || startIndex > pirateShip.Count - 1)
                    {
                        continue;
                    }
                    else if (endIndex < 0 || endIndex > pirateShip.Count - 1)
                    {
                        continue;
                    }
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        pirateShip[i] -= damage;
                        if (pirateShip[i] <= 0)
                        {
                            Console.WriteLine("You lost! The pirate ship has sunken.");
                            return;
                        }
                    }

                }
                else if (comand == "Repair")
                {
                    int index = int.Parse(commands[1]);
                    int health = int.Parse(commands[2]);

                    if (index < 0 || index > pirateShip.Count - 1)
                    {
                        continue;
                    }

                    pirateShip[index] += health;
                    if (pirateShip[index] > maxHealth)
                    {
                        pirateShip[index] = maxHealth;
                    }

                }
                else if (comand == "Status")
                {
                    int count = 0;
                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if ((double)pirateShip[i] < (double)maxHealth / 5)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine($"{count} sections need repair.");
                }
            }
            int warShipSum = 0;
            int pirateShipSum = 0;

            foreach (int i in pirateShip)
            {
                pirateShipSum += i;
            }
            foreach (int i in warShip)
            {
                warShipSum += i;
            }

            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");
        }
    }
}