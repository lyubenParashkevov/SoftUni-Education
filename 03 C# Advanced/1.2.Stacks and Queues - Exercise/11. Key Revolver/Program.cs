namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsValues = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locksValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int inteligenceMoney = int.Parse(Console.ReadLine());
            int bulletCounter = 0;
            int shotCounter = 0;

            Queue<int> locks = new Queue<int>(locksValues);
            Stack<int> bullets = new Stack<int>(bulletsValues);

            while (bullets.Count > 0 && locks.Count > 0)
            {
                int bullet = bullets.Pop();
                if (bullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                    shotCounter++;
                    bulletCounter++;
                if (shotCounter % barrelSize == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${inteligenceMoney - shotCounter * bulletPrice}");
            }
        }
    }
}