namespace _04._3_Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Shoot")
                {
                    int index = int.Parse(commands[1]);
                    int power = int.Parse(commands[2]);
                    if (index < 0 || index > targets.Count - 1)
                    {
                        continue;
                    }
                    if (power < 0)
                    {
                        continue ;
                    }
                    targets[index] -= power;
                    if (targets[index] <= 0)
                    {
                        targets.RemoveAt(index);
                    }
                }
                else if (command == "Add")
                {
                    int index = int.Parse(commands[1]);
                    int value = int.Parse(commands[2]);
                    if (value < 0)
                    {
                        continue;
                    }
                    if (index < 0 || index > targets.Count - 1)
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    else
                    {
                        targets.Insert(index, value);
                    }
                }
                else if (command == "Strike")
                {
                    int index = int.Parse(commands[1]);
                    int radius = int.Parse(commands[2]);

                    if (index < 0 || index > targets.Count - 1 )
                    {
                        continue;
                    }
                    if (index - radius < 0 || index + radius > targets.Count - 1)
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }
                    targets.RemoveRange(index - radius, radius * 2 +1);
                    
                }

            }

            Console.WriteLine(String.Join('|', targets));
        }
    }
}