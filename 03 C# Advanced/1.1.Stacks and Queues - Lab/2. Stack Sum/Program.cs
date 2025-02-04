namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            foreach (int number in numbers)
            {
                stack.Push(number);
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0].ToLower();

                if (command == "end")
                {
                    break;
                }
                if (command == "add")
                {
                    int firstNum = int.Parse(commands[1]);
                    int secondNum = int.Parse(commands[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command == "remove")
                {
                    int numbersToRemove = int.Parse(commands[1]);
                    if (numbersToRemove <= stack.Count)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}