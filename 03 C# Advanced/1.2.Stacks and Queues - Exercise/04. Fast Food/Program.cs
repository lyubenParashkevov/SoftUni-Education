namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max())
                ;
            while (queue.Count > 0 && foodQuantity > 0)
            {
                int curNum = queue.Peek();
                if (foodQuantity - curNum >= 0)
                {
                    queue.Dequeue();
                    foodQuantity -= curNum;
                }
                else
                {
                    break;
                }
            }

            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
            }

            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}