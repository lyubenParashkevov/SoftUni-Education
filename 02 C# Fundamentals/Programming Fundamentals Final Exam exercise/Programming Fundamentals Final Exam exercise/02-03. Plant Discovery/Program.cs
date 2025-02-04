namespace _02_03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> plants = new Dictionary<string, int>();
            Dictionary<string, List<int>> ratings = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());
            double averageRating = 0;
            for (int i = 0; i < n; i++)
            {
                string[] plantsInfo = Console.ReadLine().Split("<->");
                string plantName = plantsInfo[0];
                int rarity = int.Parse(plantsInfo[1]);
                if (!plants.ContainsKey(plantName))
                {
                    plants.Add(plantName, rarity);
                    ratings.Add(plantName, new List<int>());
                }
                else
                {
                    plants[plantName] = rarity;
                }
            }

            while (true)

            //"{plant}<->{rarity}". 

            {
                string input = Console.ReadLine();

                if (input == "Exhibition")
                {
                    break;
                }
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                if (command == "Rate:")
                {
                    string name = commands[1];
                    int rating = int.Parse(commands[3]);

                    if (plants.ContainsKey(name))
                    {
                        if (ratings[name].Count == 0)
                        {
                            ratings[name].Add(0);
                            ratings[name].Add(0);
                        }
                        ratings[name][0] += rating;
                        ratings[name][1]++;
                    }

                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                
                else if (command == "Update:")
                {
                    string name = commands[1];
                    int newRarity = int.Parse(commands[3]);

                    if (plants.ContainsKey(name))
                    {
                        plants[name] = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }

                }
                else if (command == "Reset:")
                {
                    string name = commands[1];

                    if (plants.ContainsKey(name))
                    {
                        ratings[name].Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var (plantName, rarity) in plants)
            {
                if (ratings[plantName].Count == 0)
                {
                    averageRating = 0;
                }
                else
                {
                    averageRating = (double)ratings[plantName][0] / ratings[plantName][1];
                }

                Console.WriteLine($"- {plantName}; Rarity: {rarity}; Rating: {averageRating:f2}");
            }
        }
    }
}