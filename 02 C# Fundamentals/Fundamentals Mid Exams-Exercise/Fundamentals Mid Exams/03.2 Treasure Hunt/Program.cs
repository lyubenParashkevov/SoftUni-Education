namespace _03._2_Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> treasure = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Yohoho!")
                {
                    break;
                }

                string[] action = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string move = action[0];

                if (move == "Loot")
                {
                    List<string> toLoot = new List<string>();
                    for (int i = 1; i < action.Length; i++)
                    {
                        toLoot.Add(action[i]);
                    }
                    for (int i = 0; i < toLoot.Count; i++)
                    {
                        if (treasure.Contains(toLoot[i]))
                        {
                            toLoot.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            treasure.Insert(0, toLoot[i]);
                        }

                    }
                    toLoot.Clear();
                }
                else if (move == "Drop")
                {
                    int index = int.Parse(action[1]);
                    if (index > treasure.Count || index < 0)
                    {
                        continue;
                    }
                    string lootToAdd = treasure[index];
                    treasure.RemoveAt(index);
                    treasure.Add(lootToAdd);

                }
                else if (move == "Steal")
                {
                    int counter = 0;
                    int numberToSteal = int.Parse(action[1]);
                    if (numberToSteal > treasure.Count)
                    {
                        Console.WriteLine(String.Join(", ", treasure));
                        Console.WriteLine("Failed treasure hunt.");
                        return;
                    }
                    List<string> stolen = new List<string>();

                    for (int i = treasure.Count - 1; i >= 0; i--)
                    {
                        stolen.Add(treasure[i]);
                        treasure.RemoveAt(i);
                        counter++;
                        if (counter == numberToSteal)
                        {
                            break;
                        }
                    }
                    stolen.Reverse();
                    Console.WriteLine(String.Join(", ", stolen));
                }
            }

            double sum = 0;
            for (int i = 0; i < treasure.Count; i++)
            {
                sum += treasure[i].Length;
            }
            if (treasure.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double finalSum = sum / treasure.Count;
                Console.WriteLine($"Average treasure gain: {finalSum:f2} pirate credits.");
            }
        }
    }
}