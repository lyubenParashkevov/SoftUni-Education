namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Queue<string> names = new Queue<string>(strings);

            int n = int.Parse(Console.ReadLine());
            string curentName = string.Empty;
            while (names.Count != 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i == n)
                    {
                        curentName = names.Dequeue();
                        Console.WriteLine($"Removed {curentName}");
                    }

                    else
                    {
                        curentName = names.Dequeue();
                        names.Enqueue(curentName);
                    }
                }
            }

            Console.WriteLine($"Last is {string.Join(" ", names)}");
        }
    }
}