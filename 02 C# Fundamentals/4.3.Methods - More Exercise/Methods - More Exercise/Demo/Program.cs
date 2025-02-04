namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commands = input.Split(' ').ToArray();
                string command = commands[0];

                if (command == "Shoot")
                {
                    int index = int.Parse(commands[1]);
                    int power = int.Parse(commands[2]);
                    ShootCommandCase(index, power, list);
                }

                else if (command == "Add")
                {
                    int index = int.Parse(commands[1]);
                    int value = int.Parse(commands[2]);
                    AddCommandCase(index, value, list);
                }

                else if (command == "Strike")
                {
                    int index = int.Parse(commands[1]);
                    int radius = int.Parse(commands[2]);
                    StrikeCommandCase(index, radius, list);
                }

                input = Console.ReadLine();

            }

            Console.WriteLine(string.Join('|', list));
        }

        static void StrikeCommandCase(int index, int radius, List<int> list)
        {
            if (index + radius  > list.Count - 1 || index - radius < 0)
            {
                Console.WriteLine("Strike missed!");
                return;
            }
            for (int i = index +1; i <= index + radius ; i++)
            {
                list.RemoveAt(i);
            }
            for (int i = index; i >= index -radius; i--)
            {
                
                list.RemoveAt(i);
            }
        }

        static void AddCommandCase(int index, int value, List<int> list)
        {
            if (index <= list.Count)
            {
                list.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        static void ShootCommandCase(int index, int power, List<int> list)
        {
            if (index <= list.Count)
            {
                list[index] -= power;
                if (list[index] <= 0)
                {
                    list.Remove(list[index]);
                }
            }
        }

    }
}